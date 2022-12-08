using DemoApplication.Areas.Client.ViewModels.Basket;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DemoApplication.Areas.Client.ViewComponents
{
    public class ShopCart : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var productsCookieValue = HttpContext.Request.Cookies["products"];
            var productsCookieViewModel = new List<ProductCookieViewModel>();

            if (productsCookieValue is not null)
            {
                productsCookieViewModel = JsonSerializer.Deserialize<List<ProductCookieViewModel>>(productsCookieValue);

            }

            return View(productsCookieViewModel);
        }
    }
}
