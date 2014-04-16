namespace Frameplate.Security.Encryption
{
    public interface IHasher
    {
        string GenerateHash(string input);
    }
}