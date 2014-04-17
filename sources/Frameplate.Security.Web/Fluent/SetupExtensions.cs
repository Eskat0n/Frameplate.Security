namespace Frameplate.Security.Web.Fluent
{
    using System.Web;
    using Security.Fluent;

    public static class SetupExtensions
    {
        public static IWebSecurityConfigurator Web(this ISecurityConfigurator securityConfigurator,
                                                   HttpApplication httpApplication)
        {
            return new WebSecurityConfigurator(httpApplication);
        }
    }
}