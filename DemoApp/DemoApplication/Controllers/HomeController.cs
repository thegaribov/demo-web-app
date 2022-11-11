using DemoApplication.Database;
using DemoApplication.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Controllers
{
    public class HomeController : Controller
    {
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
        public ActionResult Contact([FromForm] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            contact.Id = TablePkAutoincrement.ContactCounter;
            DatabaseAccess.Contacts.Add(contact);

            return RedirectToAction("contacts");
        }

        [HttpGet]
        public List<Contact> Contacts()
        {
            return DatabaseAccess.Contacts;
        }
    }
}
