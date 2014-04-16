namespace Frameplate.Security
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;

    public class OnlyForAuthenticated : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return httpContext.User == null || httpContext.Request.IsAuthenticated;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var httpContext = filterContext.HttpContext;

            var appPath = httpContext.Request.ApplicationPath == "/"
                ? string.Empty
                : httpContext.Request.ApplicationPath;

            if (httpContext.Request.Url == null)
                return;

            var path = HttpUtility.UrlEncode(httpContext.Request.Url.PathAndQuery);
            var url = string.Format("{0}{1}?ReturnUrl={2}", appPath, FormsAuthentication.LoginUrl, path);

            if (filterContext.IsChildAction == false)
                filterContext.Result = new RedirectResult(url);
        }
    }
}