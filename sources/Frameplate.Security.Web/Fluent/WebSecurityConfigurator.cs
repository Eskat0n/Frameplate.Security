namespace Frameplate.Security.Web.Fluent
{
    using System.Web;
    using System.Web.Mvc;
    using Configuration;

    internal class WebSecurityConfigurator : IWebSecurityConfigurator
    {
        private readonly HttpApplication _httpApplication;

        public WebSecurityConfigurator(HttpApplication httpApplication)
        {
            _httpApplication = httpApplication;
        }

        public IWebSecurityConfigurator SingInAt(string action, string controller)
        {
            WebSettings.SignInAction = action;
            WebSettings.SignInController = controller;

            return this;
        }

        public IWebSecurityConfigurator SingOutAt(string action, string controller)
        {
            WebSettings.SignOutAction = action;
            WebSettings.SignOutController = controller;

            return this;
        }

        public IWebSecurityConfigurator RegisterModules()
        {
            new AuthenticationModule().Init(_httpApplication);

            return this;
        }

        public IWebSecurityConfigurator RegisterAll()
        {
            RegisterModules();

            return this;
        }
    }
}