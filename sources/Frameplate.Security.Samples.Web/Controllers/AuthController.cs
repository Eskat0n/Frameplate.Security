namespace Frameplate.Security.Samples.Web.Controllers
{
    using System.Web.Mvc;

    public class AuthController : Controller
    {
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult SignIn(string login, string password)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}