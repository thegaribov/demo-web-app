using DemoApplication.Areas.Client.ViewModels.Basket;
using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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
            if (productCookieValue is null)
            {
                var productsCookieViewModel = new List<ProductCookieViewModel>
                {
                   new ProductCookieViewModel(product.Id, product.Title, string.Empty,  1, product.Price, product.Price)
                };

                HttpContext.Response.Cookies.Append("products", JsonSerializer.Serialize(productsCookieViewModel));
            }
            else
            {
                var productsCookieViewModel = JsonSerializer.Deserialize<List<ProductCookieViewModel>>(productCookieValue);
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
            }

            return RedirectToRoute("client-home-index");
        }
    }
}
