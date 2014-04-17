namespace Frameplate.Security.Web.Fluent
{
    using Security.Fluent;

    public static class SetupExtensions
    {
        public static IWebSecurityConfigurator Web(this ISecurityConfigurator securityConfigurator)
        {
            return new WebSecurityConfigurator();
        }
    }
}