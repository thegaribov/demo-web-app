namespace DemoApplication.Areas.Client.ViewModels.Basket
{
    public class ProductCookieViewModel
    {
        public ProductCookieViewModel(int id, string? title, string? imageUrl, int quantity, decimal price, decimal total)
        {
            Id = id;
            Title = title;
            ImageUrl = imageUrl;
            Quantity = quantity;
            Price = price;
            Total = total;
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}
