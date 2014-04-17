namespace Frameplate.Security
{
    public interface IAuthenticationService
    {
        bool SignIn<TId, TRole>(IRoleAccount<TId, TRole> account, bool isPersistent = false);
        bool SignIn<TId>(IAccount<TId> account, bool isPersistent = false);
        void SignOut();
    }
}