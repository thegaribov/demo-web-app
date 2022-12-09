using DemoApplication.Areas.Client.ViewComponents;
using DemoApplication.Areas.Client.ViewModels.Basket;
using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Xml;

namespace DemoApplication.Areas.Client.Controllers
{
    [Area("client")]
    [Route("basket")]
    public class BasketController : Controller
    {
        private readonly DataContext _dataContext;

        public BasketController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        [HttpGet("add/{id}", Name = "client-basket-add")]
        public async Task<IActionResult> AddProductAsync([FromRoute] int id)
        {
            var product = await _dataContext.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (product is null)
            {
                return NotFound();
            }

            var productCookieValue = HttpContext.Request.Cookies["products"];
            var productsCookieViewModel = productCookieValue is not null 
                ?  JsonSerializer.Deserialize<List<ProductCookieViewModel>>(productCookieValue)
                : new List<ProductCookieViewModel> { };

            var productCookieViewModel = productsCookieViewModel!.FirstOrDefault(pcvm => pcvm.Id == id);
            if (productCookieViewModel is null)
            {
                productsCookieViewModel
                    !.Add(new ProductCookieViewModel(product.Id, product.Title, string.Empty, 1, product.Price, product.Price));
            }
            else
            {
                productCookieViewModel.Quantity += 1;
                productCookieViewModel.Total = productCookieViewModel.Quantity * productCookieViewModel.Price;
            }

            HttpContext.Response.Cookies.Append("products", JsonSerializer.Serialize(productsCookieViewModel));

            return ViewComponent(nameof(ShopCart), productsCookieViewModel);
        }

        [HttpGet("delete/{id}", Name = "client-basket-delete")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute] int id)
        {
            var product = await _dataContext.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (product is null)
            {
                return NotFound();
            }

            var productCookieValue = HttpContext.Request.Cookies["products"];
            if (productCookieValue is null)
            {
                return NotFound();
            }

            var productsCookieViewModel = JsonSerializer.Deserialize<List<ProductCookieViewModel>>(productCookieValue);
            productsCookieViewModel!.RemoveAll(pcvm => pcvm.Id == id);

            HttpContext.Response.Cookies.Append("products", JsonSerializer.Serialize(productsCookieViewModel));

            return ViewComponent(nameof(ShopCart));
        }
    }
}
