using DemoApplication.Areas.Admin.ViewModels.BookImage;
using DemoApplication.Contracts.BookImage;
using DemoApplication.Validators;
using FluentValidation;

namespace DemoApplication.Areas.Admin.Validators.Admin.BookImage
{
    public class AddViewModelValidator : AbstractValidator<AddViewModel>
    {
        public AddViewModelValidator()
        {
            RuleFor(avm => avm.Image)
               .Cascade(CascadeMode.Stop)

               .NotNull()
               .WithMessage("Image can't be empty")

               .SetValidator(
                    new FileValidator(2000, 
                        FileExtensions.JPG.GetExtension(), FileExtensions.PNG.GetExtension()));
        }
    }
}
