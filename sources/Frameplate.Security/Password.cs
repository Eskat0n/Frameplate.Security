namespace Frameplate.Security
{
    using Encryption;

    public class Password
    {
        protected readonly IEncryptionProvider EncryptionProvider;

        public static Password<TEncryptionProvider> Create<TEncryptionProvider>(string password)
            where TEncryptionProvider : IEncryptionProvider, new()
        {
            return new Password<TEncryptionProvider>(password);              
        }

        protected Password(IEncryptionProvider encryptionProvider)
        {
            EncryptionProvider = encryptionProvider;
        }

        protected Password(IEncryptionProvider encryptionProvider, string password)
            : this(encryptionProvider)
        {
            Set(password);
        }

        public string Hash { get; protected set; }

        public string Salt { get; protected set; }

        protected virtual void Set(string password)
        {
            Salt = EncryptionProvider.GenerateSalt();
            Hash = EncryptionProvider.GenerateHash(string.Concat(password, Salt));
        }

        public virtual void Change(string password)
        {
            Set(password);
        }

        protected bool Equals(Password other)
        {
            return string.Equals(Hash, other.Hash) &&
                   string.Equals(Salt, other.Salt);
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.GetType() == GetType() &&
                   Equals((Password) other);
        }

        public bool Equals(string other)
        {
            return Equals(new Password(EncryptionProvider, other));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Hash != null ? Hash.GetHashCode() : 0)*397) ^ (Salt != null ? Salt.GetHashCode() : 0);
            }
        }        
    }
}