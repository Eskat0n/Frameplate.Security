namespace Frameplate.Security.Samples.Web.Controllers
{
    using System.Web.Mvc;

    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Content("Only for account with User role", "text/html");
        } 
    }
}