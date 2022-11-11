using DemoApplication.Controllers;
using DemoApplication.Database.Models;

namespace DemoApplication.Database
{
    public class DatabaseAccess
    {
        public static List<Book> Books { get; set; } = new List<Book>();
    }
}
