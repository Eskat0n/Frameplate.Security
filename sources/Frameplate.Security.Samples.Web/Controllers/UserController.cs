namespace Frameplate.Security.Samples.Web.Controllers
{
    using System.Web.Mvc;
    using Models;
    using Security.Web;

    public class UserController : Controller
    {
        [HttpGet]
        [OnlyFor(Role.User)]
        public ActionResult Index()
        {
            return Content("Only for account with User role", "text/html");
        } 
    }
}