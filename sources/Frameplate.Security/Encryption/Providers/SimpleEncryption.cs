namespace Frameplate.Security.Encryption.Providers
{
    using Hashers;
    using Salters;

    public class SimpleEncryption : EncryptionProviderBase
    {
        public SimpleEncryption()
            : base(new Md5Hasher(), new RandomSalter())
        {
        }
    }
}