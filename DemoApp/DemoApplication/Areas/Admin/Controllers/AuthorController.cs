using DemoApplication.Areas.Admin.ViewComponents;
using DemoApplication.Areas.Admin.ViewModels.Author;
using DemoApplication.Database;
using DemoApplication.Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DemoApplication.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/author")]
    [Authorize(Roles = "admin")]
    public class AuthorController : Controller
    {
        private readonly DataContext _dataContext;

        public AuthorController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region List

        [HttpGet("list", Name = "admin-author-list")]
        public IActionResult List()
        {
            var model = _dataContext.Authors
                .OrderByDescending(a => a.CreatedAt)
                .Select(a => new ListItemViewModel(a.Id, a.FirstName, a.LastName))
                .ToList();

            return View(model);
        }

        #endregion

        #region Add

        [HttpPost("add", Name = "admin-author-add")]
        public async Task<IActionResult> AddAsync(AddViewModel? model)
        {
            if (!ModelState.IsValid)
            {
                var addModelViewComponent = ViewComponent(nameof(AddModal), model);
                addModelViewComponent.StatusCode = (int)HttpStatusCode.BadRequest;
                return addModelViewComponent;
            }

            var author = new Author
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            await _dataContext.Authors.AddAsync(author);
            await _dataContext.SaveChangesAsync();

            var responseModel = new ListItemViewModel(author.Id, author.FirstName, author.LastName);

            var listItemPartialView = PartialView("Partials/Author/_ListItem", responseModel);
            listItemPartialView.StatusCode = (int)HttpStatusCode.Created;
            return listItemPartialView;
        }

        #endregion

        [HttpGet("update/{id}", Name = "admin-author-update")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id)
        {
            var author = await _dataContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author is null)
            {
                return NotFound();
            }

            var model = new UpdateViewModel
            {
                FirstName = author.FirstName,
                LastName = author.LastName
            };

            return PartialView("Partials/Author/_Update", model);
        }

        [HttpPut("update/{id}", Name = "admin-author-update")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromForm] UpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var updatePartialResult = PartialView("Partials/Author/_Update", model);
                updatePartialResult.StatusCode = (int)HttpStatusCode.BadRequest;
                return updatePartialResult;
            }

            var author = await _dataContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author is null)
            {
                return NotFound();
            }

            author.FirstName = model.FirstName;
            author.LastName = model.LastName;
            author.UpdatedAt = DateTime.Now;

            await _dataContext.SaveChangesAsync();

            var responseModel = new ListItemViewModel(author.Id, author.FirstName, author.LastName);
            return PartialView("Partials/Author/_ListItem", responseModel);
        }

        #region Delete

        [HttpDelete("delete/{id}", Name = "admin-author-delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var author = await _dataContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author is null)
            {
                return NotFound();
            }

            _dataContext.Authors.Remove(author);
            await _dataContext.SaveChangesAsync();

            return NoContent();
        }

        #endregion
    }
}
