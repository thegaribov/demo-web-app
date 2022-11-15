using DemoApplication.Controllers;
using DemoApplication.Database.Models;

namespace DemoApplication.Database
{
    public class DatabaseAccess
    {
        public static List<User> Users { get; set; } = new List<User>();
        public static List<Contact> Contacts { get; set; } = new List<Contact>();
    }

    public class TablePkAutoincrement
    {
        private static int contactCounter;
        private static int userCounter;

        public static int ContactCounter
        {
            get { return ++contactCounter; }
        }
        public static int UserCounter
        {
            get { return ++userCounter; }
        }
    }
}
