using DemoApplication.Controllers;
using DemoApplication.Database.Models;

namespace DemoApplication.Database
{
    public class DatabaseAccess
    {
        public static List<Book> Books { get; set; } = new List<Book>();
        public static List<Contact> Contacts { get; set; } = new List<Contact>();
    }

    public class TablePkAutoincrement
    {
        private static int contactCounter;

        public static int ContactCounter
        {
            get { return ++contactCounter; }
        }

    }
}
