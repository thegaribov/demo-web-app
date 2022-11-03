using DemoApplication.Database.Models;

namespace DemoApplication.ViewModels.Home
{
    public class IndexViewModel
    {
        public IndexViewModel(List<Flower> flowers, List<Expert> experts)
        {
            Flowers = flowers;
            Experts = experts;
        }

        public List<Flower> Flowers { get; set; }
        public List<Expert> Experts { get; set; }

    }
}
