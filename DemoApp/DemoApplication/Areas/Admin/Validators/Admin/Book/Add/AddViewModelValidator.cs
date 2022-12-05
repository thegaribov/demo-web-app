using DemoApplication.Areas.Admin.ViewModels.Book.Add;
using FluentValidation;

namespace DemoApplication.Areas.Admin.Validators.Admin.Book.Add
{
    public class AddViewModelValidator : AbstractValidator<AddViewModel>
    {
        public AddViewModelValidator()
        {
            RuleFor(avm => avm.Title)
                .NotNull()
                .WithMessage("Title can't be empty")
                .NotEmpty()
                .WithMessage("Title can't be empty")
                .MinimumLength(10)
                .WithMessage("Minimum length should be 10")
                .MaximumLength(45)
                .WithMessage("Maximum length should be 45");
        }
    }
}
