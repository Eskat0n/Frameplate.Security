namespace Frameplate.Security.Encryption
{
    public interface ISalter
    {
        string GenerateSalt();
    }
}