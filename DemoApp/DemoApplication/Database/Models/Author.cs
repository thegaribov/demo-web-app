namespace DemoApplication.Database.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        List<Book> Books { get; set; }
    }
}
