using DemoApplication.Database;
using DemoApplication.Services.Abstracts;
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
        private readonly IUserService _userService;

        public AccountController(DataContext dataContext, IUserService userService)
        {
            _dataContext = dataContext;
            _userService = userService;
        }

        [HttpGet("dashboard", Name = "client-account-dashboard")]
        public IActionResult Dashboard()
        {
            var user = _userService.CurrentUser;
            var user2 = _userService.CurrentUser;

            return View();
        }

        [HttpGet("orders", Name = "client-account-orders")]
        public IActionResult Orders()
        {
            var user = _userService.CurrentUser;
            var user2 = _userService.CurrentUser;

            return View();
        }
    }
}
