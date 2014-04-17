namespace Frameplate.Security
{
    public interface IHaveRole<out TRole>
    {
        TRole Role { get; }
    }
}