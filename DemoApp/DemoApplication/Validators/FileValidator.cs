using FluentValidation;

namespace DemoApplication.Validators
{
    public class FileValidator : AbstractValidator<IFormFile>
    {
        public FileValidator() { }

        public FileValidator(long size, params string[] extensions)
        {
            RuleFor(i => i.Length)
                .LessThanOrEqualTo(size)
                .WithMessage($"Image size should be less that : {size}");

            RuleFor(i => i.FileName)
                .Must(fn => extensions.Contains(Path.GetExtension(fn)))
                .WithMessage($"Image extension shold be {string.Join(", ", extensions)}");
        }
    }
}
