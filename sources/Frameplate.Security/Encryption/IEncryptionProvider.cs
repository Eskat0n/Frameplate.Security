namespace Frameplate.Security.Encryption
{
    public interface IEncryptionProvider : IHasher, ISalter
    {
    }
}