namespace Frameplate.Security.Samples.Web.Controllers
{
    using System.Web.Mvc;
    using Models;
    using Security.Web;

    public class AdminController : Controller
    {
        [HttpGet]
        [OnlyFor(Role.Admin)]
        public ActionResult Index()
        {
            return Content("Only for account with Admin role", "text/html");
        } 
    }
}