namespace DemoApplication.Areas.Client.ViewModels.Book
{
    public class DetailsViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }

        public DetailsViewModel(string title, string author, decimal price, DateTime createdAt)
        {
            Title = title;
            Author = author;
            Price = price;
            CreatedAt = createdAt;
        }
    }
}
