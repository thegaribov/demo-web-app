using DemoApplication.Areas.Admin.ViewComponents;
using DemoApplication.Areas.Admin.ViewModels.Author;
using DemoApplication.Database;
using DemoApplication.Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DemoApplication.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/author")]
    public class AuthorController : Controller
    {
        private readonly DataContext _dataContext;

        public AuthorController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("list", Name = "admin-author-list")]
        public IActionResult List()
        {
            var model = _dataContext.Authors
                .OrderByDescending(a => a.CreatedAt)
                .Select(a => new ListItemViewModel(a.Id, a.FirstName, a.LastName))
                .ToList();

            return View(model);
        }

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
    }
}
