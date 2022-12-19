using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Areas.Admin.ViewModels.Author
{
    public class AddViewModel
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }
    }
}
