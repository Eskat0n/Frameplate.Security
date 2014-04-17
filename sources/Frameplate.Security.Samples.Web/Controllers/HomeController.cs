namespace Frameplate.Security.Samples.Web.Controllers
{
    using System.Web.Mvc;
    using Security.Web;

    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [OnlyForAuthenticated]
        public ActionResult Private()
        {
            return Content("Only for authenticated accounts", "text/html");
        } 
    }
}