namespace DemoApplication.Database.Models
{
    public class Flower
    {
        public Flower(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
