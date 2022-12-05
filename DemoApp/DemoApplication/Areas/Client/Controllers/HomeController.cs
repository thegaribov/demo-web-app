using DemoApplication.Areas.Client.ViewModels.Home.Contact;
using DemoApplication.Database;
using DemoApplication.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Areas.Client.Controllers
{
    [Area("client")]
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly DataContext _dbContext;

        public HomeController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("~/")]
        [HttpGet("index")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("contact")]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public ActionResult Contact([FromForm] CreateViewModel contactViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _dbContext.Contacts.Add(new Contact
            {
                Name = contactViewModel.Name,
                Email = contactViewModel.Email,
                Message = contactViewModel.Message,
                Phone = contactViewModel.PhoneNumber,
                CreatedAt = DateTime.Now
            });

            return RedirectToAction(nameof(Index));
        }
    }
}
