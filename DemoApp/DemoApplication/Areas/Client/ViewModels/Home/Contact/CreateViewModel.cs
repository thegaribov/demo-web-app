using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Areas.Client.ViewModels.Home.Contact
{
    public class CreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

    }
}
