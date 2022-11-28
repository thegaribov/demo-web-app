using DemoApplication.Database;
using DemoApplication.ViewModels.Admin.Book;
using Microsoft.AspNetCore.Mvc;

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
    }
}
