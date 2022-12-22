using DemoApplication.Areas.Client.ViewModels.Authentication;
using DemoApplication.Areas.Client.ViewModels.Basket;
using DemoApplication.Database.Models;

namespace DemoApplication.Services.Abstracts
{
    public interface IBasketService
    {
        Task<List<ProductCookieViewModel>> AddBasketProductAsync(Book book);
    }
}
