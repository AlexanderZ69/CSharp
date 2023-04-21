using FluentValidation;
using WebApp.MODELS.Request;

namespace WebApplicationN.Validators
{
    public class AddAuthorRequestValidator :
        AbstractValidator<AddAuthorRequest>
    {
        public AddAuthorRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Write Something!")
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(10);

            RuleFor(x => x.Bio)
                .NotEmpty();
        }
    }
}
