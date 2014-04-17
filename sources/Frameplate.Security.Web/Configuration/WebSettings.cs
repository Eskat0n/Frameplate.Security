namespace Frameplate.Security.Web.Configuration
{
    internal static class WebSettings
    {
        static WebSettings()
        {
            ReturnUrl = true;
            ReturnUrlParameter = "ReturnUrl";
        }

        public static bool ReturnUrl { get; set; }
        public static string ReturnUrlParameter { get; set; }
    }
}