using DemoApplication.Database.Models.Common;

namespace DemoApplication.Database.Models
{
    public class Book : BaseEntity, IAuditable
    {
        public string Title { get; set; }
        public decimal Price { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
