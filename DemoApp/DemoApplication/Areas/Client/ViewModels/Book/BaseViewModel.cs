using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Areas.Client.ViewModels.Book
{
    public abstract class BaseViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public decimal? Price { get; set; }
    }
}
