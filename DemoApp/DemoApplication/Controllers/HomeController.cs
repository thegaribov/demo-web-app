using DemoApplication.Database;
using DemoApplication.Database.Models;
using DemoApplication.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Controllers
{
    public class HomeController : Controller
    {



        public ViewResult Index()
        {
            var flowers = DatabaseAccess.Flowers;
            var experts = DatabaseAccess.Experts;

            return View(new IndexViewModel(flowers, experts));
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
