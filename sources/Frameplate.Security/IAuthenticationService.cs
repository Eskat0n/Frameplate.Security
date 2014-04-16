namespace Frameplate.Security
{
    public interface IAuthenticationService
    {
        bool SignIn<TId>(IAccount<TId> account, bool isPersistent = false);
        void SignOut();
    }
}