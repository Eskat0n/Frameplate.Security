namespace Frameplate.Security
{
    public interface IAccount<out TId>
    {
        TId Id { get; }

        string Login { get; }
    }
}