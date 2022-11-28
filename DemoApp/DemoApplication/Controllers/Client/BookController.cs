using DemoApplication.Database;
using DemoApplication.Database.Models;
using DemoApplication.Services.Abstracts;
using DemoApplication.ViewModels.Client.Book;
using DemoApplication.ViewModels.Client.Book.Update;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DemoApplication.Controllers.Client
{
    [Route("book")]
    public class BookController : Controller
    {
        private readonly DataContext _dbContext;
        private readonly IEmailService _emailService;

        public BookController(DataContext dbContext, IEmailService emailService)
        {
            _dbContext = dbContext;
            _emailService = emailService;
        }

        #region Read

        [HttpGet("list", Name = "book-list")]
        public ActionResult List()
        {
            var model = _dbContext.Books
                .Select(b => new ListItemViewModel(b.Id, b.Title, b.Price, b.CreatedAt))
                .ToList();

            return View("~/Views/Client/Book/List.cshtml", model);
        }

        [HttpGet("detail/{id}", Name = "book-details")]
        public ActionResult Details([FromRoute] int id)
        {
            var book = _dbContext.Books.Where(b => b.Id == id).FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }

            var model = new DetailsViewModel(book.Title, string.Empty, book.Price, book.CreatedAt);
            return View("~/Views/Client/Book/Details.cshtml", model);
        }

        #endregion

        #region Add

        [HttpGet("add", Name = "book-add")]
        public ActionResult Add()
        {
            return View("~/Views/Client/Book/Add.cshtml");
        }

        [HttpPost("add", Name = "book-add")]
        public ActionResult Add(AddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Client/Book/Add.cshtml", model);
            }

            _dbContext.Books.Add(new Book
            {
                Title = model.Title,
                //Author = model.Author,
                Price = model.Price.Value,
                CreatedAt = DateTime.Now
            });

            return RedirectToAction(nameof(List));
        }

        #endregion

        #region Update

        [HttpGet("update/{id}", Name = "book-update")]
        public ActionResult Update([FromRoute] int id)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == id);
            if (book is null)
            {
                return NotFound();
            }

            return View("~/Views/Client/Book/Update.cshtml", new UpdateResponseViewModel { Id = book.Id, Title = book.Title, /*Author = book.Author, */Price = book.Price });
        }

        [HttpPost("update/{id}", Name = "book-update")]
        public ActionResult Update([FromRoute] int id, [FromForm] UpdateRequestViewModel model)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == id);
            if (book is null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View("~/Views/Client/Book/Update.cshtml", model);
            }

            book.Title = model.Title;
            //book.Author = model.Author;
            book.Price = model.Price.Value;

            return RedirectToAction(nameof(List));
        }


        #endregion

        #region Delete

        [HttpGet("delete", Name = "book-delete-bulk")]
        public ActionResult Delete()
        {
            //_dbContext.Books.re

            return RedirectToAction(nameof(List));
        }

        [HttpGet("delete/{id}", Name = "book-delete-individual")]
        public ActionResult Delete(int id)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == id);
            if (book is null)
            {
                return NotFound();
            }

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(List));
        }

        #endregion
    }
}

