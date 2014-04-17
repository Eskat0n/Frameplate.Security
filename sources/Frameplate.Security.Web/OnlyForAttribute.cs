namespace Frameplate.Security.Web
{
    using System;
    using System.Linq;
    using System.Web;

    public class OnlyForAttribute : OnlyForAuthenticated
    {
        private readonly object[] _roles;

        public OnlyForAttribute(params object[] roles)
        {
            if (roles == null) 
                throw new ArgumentNullException("roles");

            _roles = roles
                .Where(x => x != null)
                .ToArray();
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var principal = HttpContext.Current.User;
            return base.AuthorizeCore(httpContext) &&
                   principal != null &&
                   _roles.Any(x => principal.IsInRole(x.ToString()));
        }
    }
}
