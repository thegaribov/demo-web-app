using DemoApplication.Database;
using DemoApplication.Database.Models;
using DemoApplication.ViewModels.Book;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Controllers
{
    [Route("book")]
    public class BookController : Controller
    {
        #region Read

        [HttpGet("list", Name = "book-list")]
        public ActionResult List()
        {
            var model = DatabaseAccess.Books
                .Select(b => new ListItemViewModel(b.Id, b.Title, b.Price, b.CreatedAt))
                .ToList();

            return View(model);
        }

        [HttpGet("detail/{id}", Name = "book-details")]
        public ActionResult Details([FromRoute] int id)
        {
            var book = DatabaseAccess.Books.Where(b => b.Id == id).FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }

            var model = new DetailsViewModel(book.Title, book.Author, book.Price, book.CreatedAt);
            return View(model);
        }

        #endregion

        #region Add

        [HttpGet("add", Name = "book-add")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost("add", Name = "book-add")]
        public ActionResult Add(AddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            DatabaseAccess.Books.Add(new Book
            {
                Id = TablePkAutoincrement.ContactCounter,
                Title = model.Title,
                Author = model.Author,
                Price = model.Price.Value,
                CreatedAt = DateTime.Now
            });

            return RedirectToAction(nameof(List));
        }

        #endregion

        #region Update

        [HttpGet("update", Name = "book-update")]
        public ActionResult Update()
        {
            return View();
        }

        [HttpGet("update", Name = "book-update")]
        public ActionResult Update(UpdateViewModel model)
        {
            return View();
        }


        #endregion

        #region Delete

        [HttpGet("delete", Name = "book-delete-bulk")]
        public ActionResult Delete()
        {
            DatabaseAccess.Books.Clear();

            return RedirectToAction(nameof(List));
        }

        [HttpGet("delete/{id}", Name = "book-delete-individual")]
        public ActionResult Delete(int id)
        {
            var book = DatabaseAccess.Books.FirstOrDefault(b => b.Id == id);
            if (book is null)
            {
                return NotFound();
            }

            DatabaseAccess.Books.Remove(book);

            return RedirectToAction(nameof(List));
        }

        #endregion
    }
}
