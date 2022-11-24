using DemoApplication.Database;
using DemoApplication.Database.Models;
using DemoApplication.ViewModels.Home.Contact;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _dbContext;

        public HomeController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
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

            return RedirectToAction(nameof(Contacts));
        }

        [HttpGet]
        public List<Contact> Contacts()
        {
            return _dbContext.Contacts.ToList();
        }
    }
}
