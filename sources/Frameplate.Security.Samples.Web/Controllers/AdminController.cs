namespace Frameplate.Security.Samples.Web.Controllers
{
    using System.Web.Mvc;

    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Content("Only for account with Admin role", "text/html");
        } 
    }
}