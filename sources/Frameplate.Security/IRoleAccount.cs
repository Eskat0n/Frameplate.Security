namespace Frameplate.Security
{
    public interface IRoleAccount<out TId, out TRole> : IAccount<TId>, IHaveRole<TRole>
    {
    }
}