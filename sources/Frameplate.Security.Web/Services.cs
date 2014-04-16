namespace Frameplate.Security.Web
{
    using System;

    public static class Services
    {
        public static class AuthenticationServices 
        {
            public static Type Forms
            {
                get { return typeof (FormsAuthenticationService); }
            }
        }
    }
}