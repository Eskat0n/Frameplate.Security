namespace Frameplate.Security.Web.Configuration
{
    internal static class WebSettings
    {
        static WebSettings()
        {
            SignInAction = null;
            SignInController = null;
            ReturnUrl = true;
            ReturnUrlParameter = "ReturnUrl";
        }

        public static string SignInAction { get; set; }
        public static string SignInController { get; set; }
        public static bool ReturnUrl { get; set; }
        public static string ReturnUrlParameter { get; set; }
    }
}