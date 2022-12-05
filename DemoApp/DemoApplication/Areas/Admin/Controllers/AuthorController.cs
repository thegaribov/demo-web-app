using DemoApplication.Database;
using DemoApplication.ViewModels.Admin.Author;
using Microsoft.AspNetCore.Mvc;

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
                .Select(a => new ListItemViewModel(a.Id, a.FirstName, a.LastName))
                .ToList();

            return View(model);
        }
    }
}
