using DemoApplication.Database;
using DemoApplication.Database.Models;
using DemoApplication.ViewModels.Admin.Book;
using DemoApplication.ViewModels.Admin.Book.Add;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace DemoApplication.Controllers.Admin
{
    [Route("admin/book")]
    public class BookController : Controller
    {
        private readonly DataContext _dataContext;

        public BookController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }



        [HttpGet("list", Name = "admin-book-list")]
        public IActionResult List()
        {
            var model = _dataContext.Books
                .Select(b => new ListItemViewModel(b.Id, b.Title, b.Price, $"{b.Author.FirstName} {b.Author.LastName}", b.CreatedAt))
                .ToList();

            return View("~/Views/Admin/Book/List.cshtml", model);
        }

        [HttpGet("add", Name = "admin-book-add")]
        public IActionResult Add()
        {
            var model = new AddViewModel
            {
                Authors = _dataContext.Authors
                .Select(a => new AuthorListItemViewModel(a.Id, $"{a.FirstName} {a.LastName}"))
                .ToList()
            };

            return View("~/Views/Admin/Book/Add.cshtml", model);
        }

        [HttpPost("add", Name = "admin-book-add")]
        public IActionResult Add(AddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return GetView(model);
            }

            if (!_dataContext.Authors.Any(a => a.Id == model.AuthorId))
            {
                ModelState.AddModelError(String.Empty, "Author is not found");

                return GetView(model);
            }

            AddBook();

            return RedirectToAction(nameof(List));




            IActionResult GetView(AddViewModel model)
            {
                model.Authors = _dataContext.Authors
                    .Select(a => new AuthorListItemViewModel(a.Id, $"{a.FirstName} {a.LastName}"))
                    .ToList();

                return View("~/Views/Admin/Book/Add.cshtml", model);
            }

            void AddBook()
            {
                var book = new Book
                {
                    Title = model.Title,
                    Price = model.Price,
                    CreatedAt = DateTime.Now,
                    AuthorId = model.AuthorId,
                };

                _dataContext.Books.Add(book);
                _dataContext.SaveChanges();
            }
        }
    }
}
