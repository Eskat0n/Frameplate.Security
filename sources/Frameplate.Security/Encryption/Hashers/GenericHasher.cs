namespace Frameplate.Security.Encryption.Hashers
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public abstract class GenericHasher : IHasher
    {
        protected readonly HashAlgorithm HashAlgorithm;

        protected GenericHasher(HashAlgorithm hashAlgorithm)
        {
            HashAlgorithm = hashAlgorithm;
        }

        public virtual string GenerateHash(string input)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var hashBytes = HashAlgorithm.ComputeHash(inputBytes);

            return Convert.ToBase64String(hashBytes);
        }
    }
}