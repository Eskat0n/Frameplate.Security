namespace Frameplate.Security.Encryption.Providers
{
    public abstract class EncryptionProviderBase : IEncryptionProvider
    {
        private readonly IHasher _hasher;
        private readonly ISalter _salter;

        protected EncryptionProviderBase(IHasher hasher, ISalter salter)
        {
            _hasher = hasher;
            _salter = salter;
        }

        public string GenerateHash(string input)
        {
            return _hasher.GenerateHash(input);
        }

        public string GenerateSalt()
        {
            return _salter.GenerateSalt();
        }
    }
}