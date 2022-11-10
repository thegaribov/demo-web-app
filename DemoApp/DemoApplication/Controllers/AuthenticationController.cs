using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
