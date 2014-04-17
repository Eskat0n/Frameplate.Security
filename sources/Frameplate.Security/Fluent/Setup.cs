namespace Frameplate.Security.Fluent
{
    public static class Security
    {
        public static ISecurityConfigurator Configure()
        {
            return new SecurityConfigurator();
        }
    }
}