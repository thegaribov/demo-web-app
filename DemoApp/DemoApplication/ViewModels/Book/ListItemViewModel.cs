namespace DemoApplication.ViewModels.Book
{
    public class ListItemViewModel
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }

        public ListItemViewModel(string title, decimal price, DateTime createdAt)
        {
            Title = title;
            Price = price;
            CreatedAt = createdAt;
        }
    }
}
