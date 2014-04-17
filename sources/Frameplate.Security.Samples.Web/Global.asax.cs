namespace Frameplate.Security.Samples.Web
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Fluent;
    using Security.Web.Fluent;

    public class MvcApplication : HttpApplication
    {
        public MvcApplication()
        {
            Security
                .Configure()
                .Web(this)
                .SingInAt("SignIn", "Auth")
                .SingOutAt("SignOut", "Auth")
                .RegisterHandlers();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}