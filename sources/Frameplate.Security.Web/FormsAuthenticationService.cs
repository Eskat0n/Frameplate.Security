namespace Frameplate.Security.Web
{
    using System;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Security;
    using Utility;

    internal class FormsAuthenticationService : IAuthenticationService
    {
        public bool SignIn<TId>(IAccount<TId> account, bool isPersistent = false) 
        {
            var accountEntry = new AccountEntry<TId>();
            var authTicket = new FormsAuthenticationTicket(1,
                                                           account.Login,
                                                           DateTime.Now,
                                                           DateTime.Now.Add(FormsAuthentication.Timeout),
                                                           isPersistent,
                                                           accountEntry.Serialize());

            var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
            {
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout),
            };

            HttpContext.Current.Response.Cookies.Add(authCookie);
            var identity = new CustomIdentity<TId>(accountEntry, authTicket.Name);
            HttpContext.Current.User = new GenericPrincipal(identity, null);

            return true;          
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}