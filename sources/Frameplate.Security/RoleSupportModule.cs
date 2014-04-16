namespace Frameplate.Security
{
    using System;
    using System.Security.Principal;
    using System.Threading;
    using System.Web;
    using System.Web.Security;
    using Utility;

    public class RoleSupportModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.PostAuthenticateRequest += OnPostAuthenticateRequest;
        }

        private static void OnPostAuthenticateRequest(object sender, EventArgs eventArgs)
        {
            var application = (HttpApplication)sender;
            var context = application.Context;

            if (context.User != null && context.User.Identity.IsAuthenticated)
                return;

            var cookieName = FormsAuthentication.FormsCookieName;
            var cookie = application.Request.Cookies[cookieName.ToUpper()];
            if (cookie == null)
                return;

            try
            {
                var ticket = FormsAuthentication.Decrypt(cookie.Value);
                if (ticket == null || ticket.Expired)
                    return;

                var identity = new CustomIdentity<int>(AccountEntry<int>.Deserialize<int>(ticket.UserData), ticket.Name);
                var principal = new GenericPrincipal(identity, new[] {"admin"});
                context.User = principal;
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