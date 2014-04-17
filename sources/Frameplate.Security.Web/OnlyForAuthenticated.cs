namespace Frameplate.Security.Web
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;
    using Configuration;

    public class OnlyForAuthenticated : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return httpContext.User == null ||
                   httpContext.Request.IsAuthenticated;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext context)
        {
            var httpContext = context.HttpContext;

            var appPath = httpContext.Request.ApplicationPath == "/"
                ? string.Empty
                : httpContext.Request.ApplicationPath;

            if (httpContext.Request.Url == null)
                return;

            var signInUrl = string.Format("{0}{1}", appPath, GetSignInUrl(context));
            if (WebSettings.ReturnUrl)
                signInUrl = string.Format("{0}?{1}={2}", signInUrl,
                                          WebSettings.ReturnUrlParameter,
                                          HttpUtility.UrlEncode(httpContext.Request.Url.PathAndQuery));

            if (context.IsChildAction == false)
                context.Result = new RedirectResult(signInUrl);
        }

        private static string GetSignInUrl(ControllerContext context)
        {
            if (WebSettings.SignInAction != null &&
                WebSettings.SignInController != null)
            {
                var urlHelper = new UrlHelper(context.RequestContext);
                return urlHelper.Action(WebSettings.SignInAction,
                                        WebSettings.SignInController);
            }

            return FormsAuthentication.LoginUrl;
        }
    }
}