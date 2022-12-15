using DemoApplication.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Areas.Client.Controllers
{
    [Area("client")]
    [Route("account")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly DataContext _dataContext;

        public AccountController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("dashboard", Name = "client-account-dashboard")]
        public IActionResult Dashboard()
        {
            var idClaim = User.Claims.FirstOrDefault(C => C.Type == "id");
            if (idClaim is null)
            {
                return NotFound();
            }

            var user = _dataContext.Users.FirstOrDefault(u => u.Id == Guid.Parse(idClaim.Value));
            if (user is null)
            {
                return NotFound();
            }





            return View();
        }
    }
}
