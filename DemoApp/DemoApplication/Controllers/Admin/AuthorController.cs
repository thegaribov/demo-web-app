using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Controllers.Admin
{
    [Route("admin/author")]
    public class AuthorController : Controller
    {
        [HttpGet("list")]
        public IActionResult List()
        {
            return View("~/Views/Admin/Author/List.cshtml");
        }
    }
}
