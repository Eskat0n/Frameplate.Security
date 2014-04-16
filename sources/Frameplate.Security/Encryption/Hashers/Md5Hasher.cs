namespace Frameplate.Security.Encryption.Hashers
{
    using System.Security.Cryptography;

    public class Md5Hasher : GenericHasher
    {
        public Md5Hasher()
            : base(MD5.Create())
        {
        }
    }
}