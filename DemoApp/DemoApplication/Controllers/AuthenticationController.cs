using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Controllers
{
    public class AuthenticationController : Controller
    {
        public ViewResult Login()
        {
            return View();
        }

        public ViewResult Register()
        {
            return View();
        }
    }
}
