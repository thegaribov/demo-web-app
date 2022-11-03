using DemoApplication.Controllers;
using DemoApplication.Database.Models;

namespace DemoApplication.Database
{
    public class DatabaseAccess
    {
        public static List<Flower> Flowers { get; set; } = new List<Flower>
        {
            new Flower("MAJESTY PALM", 259),
            new Flower("Lotus", 259),
            new Flower("Rose", 213),
            new Flower("Jasmine", 234),
            new Flower("Sunflower", 23),
            new Flower("Daisy", 23),
            new Flower("Tulip", 130),
        };

        public static List<Expert> Experts { get; set; } = new List<Expert>
        {
            new Expert("Crystal", "Brooks", "Florist"),
            new Expert("Shirley", "Harries", "Manager"),
            new Expert("Johny", "Deep", "Director")
        };
    }
}
