namespace Frameplate.Security.Web
{
    using System;
    using System.Security.Principal;
    using System.Threading;
    using System.Web;
    using System.Web.Security;
    using Utility;

    public class AuthenticationModule : IHttpModule
    {
        public void Init(HttpApplication httpApplication)
        {
            httpApplication.AuthenticateRequest += OnAuthenticateRequest;
        }

        private static void OnAuthenticateRequest(object sender, EventArgs eventArgs)
        {
            var httpApplication = (HttpApplication)sender;

            var cookieName = FormsAuthentication.FormsCookieName;
            var cookie = httpApplication.Request.Cookies[cookieName.ToUpper()];
            if (cookie == null)
                return;

            try
            {
                var ticket = FormsAuthentication.Decrypt(cookie.Value);
                if (ticket == null || ticket.Expired)
                    return;

                var accountData = AccountData.Deserialize(ticket.UserData);
                var identity = new FrameplateIdentity(accountData, ticket.Name);
                var principal = new GenericPrincipal(identity, accountData.Roles);

                httpApplication.Context.User = principal;
                Thread.CurrentPrincipal = principal;
            }
            catch
            {
            }
        }

        public void Dispose()
        {
        }
    }
}