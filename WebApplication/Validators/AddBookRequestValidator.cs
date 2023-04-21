using FluentValidation;
using WebApp.MODELS.Request;

namespace WebApplicationN.Validators
{
    public class AddBookRequestValidator :
        AbstractValidator<AddBookRequest>
    {
        public AddBookRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull().WithMessage("Cannot be 'zero'!")
                .MinimumLength(2)
                .MaximumLength(10);

            RuleFor(x => x.AuthorId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(100);   
        }
    }
}
