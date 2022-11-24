//using DemoApplication.Database;
//using DemoApplication.Database.Models;
//using DemoApplication.ViewModels.Authentication;
//using Microsoft.AspNetCore.Mvc;
//using System.Data;

//namespace DemoApplication.Controllers
//{
//    public class AuthenticationController : Controller
//    {
//        private readonly DataContext _dbContext;

//        public AuthenticationController(DataContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public ViewResult Login()
//        {
//            return View();
//        }

//        [HttpGet]
//        public ViewResult Register()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ViewResult Register(RegisterViewModel viewModel)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(viewModel);
//            }

//            //_dbContext.Users.Add(new Database.Models.User
//            //{
//            //    Id = TablePkAutoincrement.UserCounter,
//            //    Email = viewModel.Email,
//            //    Password = viewModel.Password
//            //});
//            //add to db

//            return View();
//        }
//    }
//}
