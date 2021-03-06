﻿namespace Frameplate.Security.Web
{
    using System;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Security;
    using Utility;

    internal class FormsAuthenticationService : IAuthenticationService
    {
        public bool SignIn<TId, TRole>(IRoleAccount<TId, TRole> account, bool isPersistent = false)
        {
            return SignIn(account, account.Role, isPersistent);
        }

        public bool SignIn<TId>(IAccount<TId> account, bool isPersistent = false)
        {
            return SignIn(account, (object) null, isPersistent);
        }

        private static bool SignIn<TId, TRole>(IAccount<TId> account, TRole role, bool isPersistent)
        {
            var accountData = AccountData.Create(account, role);
            var authTicket = new FormsAuthenticationTicket(1,
                                                           account.Login,
                                                           DateTime.Now,
                                                           DateTime.Now.Add(FormsAuthentication.Timeout),
                                                           isPersistent,
                                                           accountData.Serialize());

            var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
            {
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout),
            };

            HttpContext.Current.Response.Cookies.Add(authCookie);
            var identity = new FrameplateIdentity(accountData, authTicket.Name);
            HttpContext.Current.User = new GenericPrincipal(identity, accountData.Roles);

            return true;
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}