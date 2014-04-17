namespace Frameplate.Security.Web.Fluent
{
    using Annotations;

    public interface IWebSecurityConfigurator
    {
        IWebSecurityConfigurator SingInAt([AspMvcAction] string action, [AspMvcController] string controller);
        IWebSecurityConfigurator SingOutAt([AspMvcAction] string action, [AspMvcController] string controller);
        IWebSecurityConfigurator RegisterModules();
        IWebSecurityConfigurator RegisterAll();
    }
}