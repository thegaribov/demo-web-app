using DemoApplication.Areas.Client.ViewModels.Authentication;
using DemoApplication.Database;
using DemoApplication.Database.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;

namespace DemoApplication.Controllers
{
    [Area("client")]
    [Route("auth")]
    public class AuthenticationController : Controller
    {
        private readonly DataContext _dbContext;

        public AuthenticationController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Login and Logout

        [HttpGet("login", Name = "client-auth-login")]
        public async Task<IActionResult> LoginAsync()
        {
            var model = new LoginViewModel();
            return View(model);
        }


        [HttpPost("login", Name = "client-auth-login")]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
            if (user is null)
            {
                ModelState.AddModelError(String.Empty, "Email or password is not correct");
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim("id", user.Id.ToString())
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToRoute("client-home-index");
        }

        [HttpGet("logout", Name = "client-auth-logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToRoute("client-home-index");
        }

        #endregion

        #region Register

        [HttpGet("register", Name = "client-auth-register")]
        public ViewResult Register()
        {
            var model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost("register", Name = "client-auth-register")]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return RedirectToRoute("client-auth-login");
        }

        #endregion
    }
}
