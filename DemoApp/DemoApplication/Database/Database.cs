using DemoApplication.Controllers;
using DemoApplication.Database.Models;

namespace DemoApplication.Database
{
    public class DatabaseAccess
    {
        public static List<Book> Books { get; set; } = new List<Book>();
        public static List<User> Users { get; set; } = new List<User>();
        public static List<Contact> Contacts { get; set; } = new List<Contact>();
    }

    public class TablePkAutoincrement
    {
        private static int contactCounter;
        private static int userCounter;
        private static int bookCounter;

        public static int ContactCounter
        {
            get { return ++contactCounter; }
        }
        public static int UserCounter
        {
            get { return ++userCounter; }
        }
        public static int BookCounter
        {
            get { return ++bookCounter; }
        }
    }
}
