using DemoApplication.Database.Models.Common;

namespace DemoApplication.Database.Models
{
    public class Author : BaseEntity, IAuditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Book> Books { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
