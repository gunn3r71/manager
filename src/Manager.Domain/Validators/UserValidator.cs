using FluentValidation;
using Manager.Domain.Entities;
using static Manager.Shared.Regex.Expressions;

namespace Manager.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("The {PropertyName} cannot be empty.")
                .NotNull()
                .WithMessage("The {PropertyName} cannot be null.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("The {PropertyName} cannot be empty.")
                .NotNull()
                .WithMessage("The {PropertyName} cannot be null.")
                .Length(6,90)
                .WithMessage("The {PropertyName} must be between {MinLength} and {MaxLength} characters, you entered {TotalLength}.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("The {PropertyName} cannot be empty.")
                .NotNull()
                .WithMessage("The {PropertyName} cannot be null.")
                .Matches(EmailRegex)
                .WithMessage("The {PropertyName} is invalid.")
                .Length(10, 100)
                .WithMessage("The {PropertyName} must be between {MinLength} and {MaxLength} characters, you entered {TotalLength}.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("The {PropertyName} cannot be empty.")
                .NotNull()
                .WithMessage("The {PropertyName} cannot be null.")
                .Length(8)
                .WithMessage("The {PropertyName} must be {MinLength} characters, you entered {TotalLength}.")
                .Matches(PasswordRegex)
                .WithMessage("The {PropertyName} is invalid.");
        }
    }
}