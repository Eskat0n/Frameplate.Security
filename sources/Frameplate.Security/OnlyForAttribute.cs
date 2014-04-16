namespace Frameplate.Security
{
    using System.Web;

    public class OnlyForAttribute : OnlyForAuthenticated
    {
        private readonly object[] _roles;

        public OnlyForAttribute(params object[] roles)
        {
            _roles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (base.AuthorizeCore(httpContext) == false)
                return false;

//            Setup.
//            return account != null && _roles.Contains(account.Role);
            return false;
        }
    }
}
