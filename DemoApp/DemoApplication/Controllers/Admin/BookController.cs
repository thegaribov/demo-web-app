using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Controllers.Admin
{
    [Route("admin/book")]
    public class BookController : Controller
    {
        [HttpGet("list", Name = "admin-book-list")]
        public IActionResult List()
        {
            return View("~/Views/Admin/Book/List.cshtml");
        }
    }
}
