using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Areas.Admin.ViewModels.BookImage
{
    public class AddViewModel
    {
        public IFormFile? Image { get; set; }
    }
}
