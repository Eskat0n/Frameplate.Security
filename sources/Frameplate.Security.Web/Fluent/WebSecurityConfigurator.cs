namespace Frameplate.Security.Web.Fluent
{
    using System;
    using System.Security.Principal;
    using System.Threading;
    using System.Web;
    using System.Web.Security;
    using Configuration;
    using Utility;

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

        public IWebSecurityConfigurator RegisterHandlers()
        {
            _httpApplication.AuthenticateRequest += MvcApplicationOnAuthenticateRequest;

            return this;
        }

        private static void MvcApplicationOnAuthenticateRequest(object sender, EventArgs eventArgs)
        {
            var httpApplication = (HttpApplication) sender;

            var cookieName = FormsAuthentication.FormsCookieName;
            var cookie = httpApplication.Request.Cookies[cookieName.ToUpper()];
            if (cookie == null)
                return;

            try
            {
                var ticket = FormsAuthentication.Decrypt(cookie.Value);
                if (ticket == null || ticket.Expired)
                    return;

                var identity = new FrameplateIdentity(AccountData.Deserialize(ticket.UserData), ticket.Name);
                var principal = new GenericPrincipal(identity, null);
                httpApplication.Context.User = principal;
                Thread.CurrentPrincipal = principal;
            }
            catch
            {
            }
        }
    }
}