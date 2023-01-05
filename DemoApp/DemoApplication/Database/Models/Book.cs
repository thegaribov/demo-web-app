using DemoApplication.Database.Models.Common;

namespace DemoApplication.Database.Models
{
    public class Book : BaseEntity<int>, IAuditable
    {
        public string Title { get; set; }
        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public List<BookCategory>? BookCategories { get; set; }
        public List<BasketProduct>? BasketProducts { get; set; }

        public string? ImageName { get; set; } //<original_name>.<extension>
        public string? ImageNameInFileSystem { get; set; } //Guid.<extension>
    }
}
