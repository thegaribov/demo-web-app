using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Controllers
{
    public class HomeController : Controller
    {



        public ViewResult Index()
        {
            var flowers = DatabaseAccess.Flowers;

            return View(flowers);
        }

        public ViewResult About()
        {
            return View();
        }

        public ViewResult Contact()
        {
            return View();
        }

    }
}
