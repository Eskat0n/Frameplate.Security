namespace Frameplate.Security.Samples.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Repositories;
    using Security.Web;

    public class AuthController : Controller
    {
        private readonly IAuthenticationService _authService;

        public AuthController()
        {
            _authService = (IAuthenticationService) Activator.CreateInstance(
                Services.AuthenticationServices.Forms);
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult SignIn(string login, string password)
        {
            var account = AccountRepository.Accounts
                .SingleOrDefault(x => x.Login == login && x.Password == password);

            if (account != null)
                _authService.SignIn(account);

            return RedirectToAction("Index", "Home");
        }
    }
}