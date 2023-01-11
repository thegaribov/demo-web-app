using DemoApplication.Areas.Client.ViewModels.Home.Contact;
using DemoApplication.Areas.Client.ViewModels.Home.Index;
using DemoApplication.Contracts.File;
using DemoApplication.Database;
using DemoApplication.Database.Models;
using DemoApplication.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        [HttpGet("~/", Name = "client-home-index")]
        [HttpGet("index")]
        public async Task<IActionResult> IndexAsync([FromServices] IFileService fileService)
        {
            var model = new IndexViewModel
            {
                Books = await _dbContext.Books
                .Select(b => new BookListItemViewModel(
                    b.Id,
                    b.Title,
                    $"{b.Author.FirstName} {b.Author.LastName}",
                    b.Price,
                    b.BookImages!.Take(1)!.FirstOrDefault()! != null
                        ? fileService.GetFileUrl(b.BookImages!.Take(1)!.FirstOrDefault()!.ImageNameInFileSystem!, UploadDirectory.Book)
                        : string.Empty,
                    b.BookImages!.Skip(1).Take(1)!.FirstOrDefault()! != null
                        ? fileService.GetFileUrl(b.BookImages!.Skip(1)!.Take(1)!.FirstOrDefault()!.ImageNameInFileSystem!, UploadDirectory.Book)
                        : string.Empty)
                )
                .ToListAsync(),
            };



            return View(model);
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
            });

            return RedirectToAction(nameof(Index));
        }
    }
}
