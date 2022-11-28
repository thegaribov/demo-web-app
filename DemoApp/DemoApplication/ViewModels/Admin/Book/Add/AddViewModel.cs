
using System.ComponentModel.DataAnnotations;

namespace DemoApplication.ViewModels.Admin.Book.Add
{
    public class AddViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public List<AuthorListItemViewModel>? Authors { get; set; }
    }
}
