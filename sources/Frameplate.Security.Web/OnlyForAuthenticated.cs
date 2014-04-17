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

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var httpContext = filterContext.HttpContext;

            var appPath = httpContext.Request.ApplicationPath == "/"
                ? string.Empty
                : httpContext.Request.ApplicationPath;

            if (httpContext.Request.Url == null)
                return;

            var path = HttpUtility.UrlEncode(httpContext.Request.Url.PathAndQuery);
            var url = string.Format("{0}{1}", appPath, FormsAuthentication.LoginUrl);
            if (WebSettings.ReturnUrl)
                url = string.Format("{0}?ReturnUrl={1}", url, path);

            if (filterContext.IsChildAction == false)
                filterContext.Result = new RedirectResult(url);
        }
    }
}