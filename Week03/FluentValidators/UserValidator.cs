using FluentValidation;
using Week03.Models;

namespace Week03.FluentValidators
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");

            RuleFor(user => user.Surname)
                .NotEmpty().WithMessage("Surname is required.")
                .Length(2, 50).WithMessage("Surname must be between 2 and 50 characters.");

            RuleFor(user => user.Age)
                .NotEmpty().WithMessage("Age is required.")
                .InclusiveBetween(18, 100).WithMessage("Age must be between 18 and 100.");
        }
    }
}
