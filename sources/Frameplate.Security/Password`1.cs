namespace Frameplate.Security
{
    using Encryption;

    public class Password<TEncryptionProvider> : Password
        where TEncryptionProvider : IEncryptionProvider, new()
    {
        public Password()
            : base(new TEncryptionProvider())
        {
        }

        public Password(string password)
            : base(new TEncryptionProvider(), password)
        {
        }

        public static implicit operator Password<TEncryptionProvider>(string password)
        {
            return new Password<TEncryptionProvider>(password);
        }
    }
}