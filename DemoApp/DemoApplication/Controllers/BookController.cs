using DemoApplication.Database;
using DemoApplication.Database.Models;
using DemoApplication.ViewModels.Book;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Controllers
{
    public class BookController : Controller
    {
        #region Read

        [HttpGet]
        public ActionResult List()
        {
            var model = DatabaseAccess.Books
                .Select(b => new ListItemViewModel(b.Title, b.Price, b.CreatedAt))
                .ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }

        #endregion

        #region Add

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddViewModel model)
        {
            if (!ModelState.IsValid )
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

        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(UpdateViewModel  model)
        {
            return View();
        }


        #endregion

        #region Delete

        [HttpPost]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return View();
        }

        #endregion
    }
}
