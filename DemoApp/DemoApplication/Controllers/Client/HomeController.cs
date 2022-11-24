using DemoApplication.Database;
using DemoApplication.Database.Models;
using DemoApplication.ViewModels.Client.Home.Contact;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Controllers.Client
{
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
            return View("~/Views/Client/Home/Index.cshtml");
        }

        [HttpGet("contact")]
        public ActionResult Contact()
        {
            return View("~/Views/Client/Home/Contact.cshtml");
        }

        [HttpPost("contact")]
        public ActionResult Contact([FromForm] CreateViewModel contactViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Client/Home/Contact.cshtml");
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
