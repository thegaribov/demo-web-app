using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Areas.Client.ViewModels.Authentication
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Compare(nameof(Password), ErrorMessage = "Password and confirm password is not same")]
        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
