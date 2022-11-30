using DemoApplication.Database;
using DemoApplication.Database.Models;
using DemoApplication.ViewModels.Admin.Book;
using DemoApplication.ViewModels.Admin.Book.Add;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace DemoApplication.Controllers.Admin
{
    [Route("admin/book")]
    public class BookController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<BookController> _logger;

        public BookController(DataContext dataContext, ILogger<BookController> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }


        #region List

        [HttpGet("list", Name = "admin-book-list")]
        public IActionResult List()
        {
            var model = _dataContext.Books
                .Select(b => new ListItemViewModel(b.Id, b.Title, b.Price, $"{b.Author.FirstName} {b.Author.LastName}", b.CreatedAt))
                .ToList();

            return View("~/Views/Admin/Book/List.cshtml", model);
        }

        #endregion

        #region Add

        [HttpGet("add", Name = "admin-book-add")]
        public IActionResult Add()
        {
            var model = new AddViewModel
            {
                Authors = _dataContext.Authors
                    .Select(a => new AuthorListItemViewModel(a.Id, $"{a.FirstName} {a.LastName}"))
                    .ToList(),
                Categories = _dataContext.Categories
                    .Select(c => new CategoryListItemViewModel(c.Id, c.Title))
                    .ToList(),
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

            foreach (var categoryId in model.CategoryIds)
            {
                if (!_dataContext.Categories.Any(c => c.Id == categoryId))
                {
                    ModelState.AddModelError(String.Empty, "Something went wrong");
                    _logger.LogWarning($"Category with id({categoryId}) not found in db ");
                    return GetView(model);
                }

            }


            AddBook();

            return RedirectToAction(nameof(List));




            IActionResult GetView(AddViewModel model)
            {
                model.Authors = _dataContext.Authors
                    .Select(a => new AuthorListItemViewModel(a.Id, $"{a.FirstName} {a.LastName}"))
                    .ToList();

                model.Categories = _dataContext.Categories
                   .Select(c => new CategoryListItemViewModel(c.Id, c.Title))
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

                foreach (var categoryId in model.CategoryIds)
                {
                    var bookCategory = new BookCategory
                    {
                        CategoryId = categoryId,
                        Book = book,
                    };

                    _dataContext.BookCategories.Add(bookCategory);
                }

                _dataContext.SaveChanges();
            }
        }


        #endregion

        #region Update

        [HttpGet("update/{id}", Name = "admin-book-update")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id)
        {
            var book = await _dataContext.Books.Include(b => b.BookCategories).FirstOrDefaultAsync(b => b.Id == id);
            if (book is null)
            {
                return NotFound();
            }

            var model = new AddViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Price = book.Price,
                AuthorId = book.AuthorId,
                Authors = _dataContext.Authors
                    .Select(a => new AuthorListItemViewModel(a.Id, $"{a.FirstName} {a.LastName}"))
                    .ToList(),
                Categories = _dataContext.Categories
                    .Select(c => new CategoryListItemViewModel(c.Id, c.Title))
                    .ToList(),
                CategoryIds = book.BookCategories.Select(bc => bc.CategoryId).ToList()
            };

            return View("~/Views/Admin/Book/Update.cshtml", model);
        }

        [HttpPost("update/{id}", Name = "admin-book-update")]
        public async Task<IActionResult> UpdateAsync(AddViewModel model)
        {
            var book = await _dataContext.Books.Include(b => b.BookCategories).FirstOrDefaultAsync(b => b.Id == model.Id);
            if (book is null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return GetView(model);
            }

            if (!_dataContext.Authors.Any(a => a.Id == model.AuthorId))
            {
                ModelState.AddModelError(String.Empty, "Author is not found");
                return GetView(model);
            }

            foreach (var categoryId in model.CategoryIds)
            {
                if (!_dataContext.Categories.Any(c => c.Id == categoryId))
                {
                    ModelState.AddModelError(String.Empty, "Something went wrong");
                    _logger.LogWarning($"Category with id({categoryId}) not found in db ");
                    return GetView(model);
                }

            }


            await UpdateBookAsync();

            return RedirectToAction(nameof(List));




            IActionResult GetView(AddViewModel model)
            {
                model.Authors = _dataContext.Authors
                    .Select(a => new AuthorListItemViewModel(a.Id, $"{a.FirstName} {a.LastName}"))
                    .ToList();

                model.Categories = _dataContext.Categories
                   .Select(c => new CategoryListItemViewModel(c.Id, c.Title))
                   .ToList();

                model.CategoryIds = book.BookCategories.Select(bc => bc.CategoryId).ToList();

                return View("~/Views/Admin/Book/Add.cshtml", model);
            }

            async Task UpdateBookAsync()
            {
                book.Title = model.Title;
                book.AuthorId = model.AuthorId;
                book.Price = model.Price;
                book.UpdatedAt = DateTime.Now;

                var categoriesInDb = book.BookCategories.Select(bc => bc.CategoryId).ToList();
                var categoriesToRemove = categoriesInDb.Except(model.CategoryIds).ToList();
                var categoriesToAdd = model.CategoryIds.Except(categoriesInDb).ToList();

                book.BookCategories.RemoveAll(bc => categoriesToRemove.Contains(bc.CategoryId));

                foreach (var categoryId in categoriesToAdd)
                {
                    var bookCategory = new BookCategory
                    {
                        CategoryId = categoryId,
                        Book = book,
                    };

                    _dataContext.BookCategories.Add(bookCategory);
                }

                _dataContext.SaveChanges();
            }
        }

        #endregion

        #region Delete

        [HttpPost("delete/{id}", Name = "admin-book-delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var book = await _dataContext.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book is null)
            {
                return NotFound();
            }

            _dataContext.Books.Remove(book);
            await _dataContext.SaveChangesAsync();

            return RedirectToRoute("admin-book-list");
        } 

        #endregion
    }
}
