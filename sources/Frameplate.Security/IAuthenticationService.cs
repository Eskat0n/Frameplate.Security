namespace Frameplate.Security
{
    public interface IAuthenticationService
    {
        bool SignIn<TId, TAccount>(TAccount account, bool isPersistent = false)
            where TAccount : class, IAccount<TId>;
        void SignOut();
    }
}