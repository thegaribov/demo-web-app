using DemoApplication.Areas.Client.ViewModels.Authentication;
using DemoApplication.Areas.Client.ViewModels.Basket;
using DemoApplication.Contracts.Identity;
using DemoApplication.Database;
using DemoApplication.Database.Models;
using DemoApplication.Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.Json;

namespace DemoApplication.Services.Abstracts
{
    public class BasketService : IBasketService
    {
        private readonly DataContext _dataContext;

        public BasketService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
