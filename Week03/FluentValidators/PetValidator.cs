using FluentValidation;
using Week03.Models;

namespace Week03.FluentValidators
{
    public class PetValidator : AbstractValidator<Pet>
    {
        public PetValidator()
        {
            RuleFor(pet => pet.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");

            RuleFor(pet => pet.Type)
                .NotEmpty().WithMessage("Type is required.")
                .Length(2, 50).WithMessage("Type must be between 2 and 50 characters.");

            RuleFor(pet => pet.Age)
                .GreaterThanOrEqualTo(0).WithMessage("Age must be a non-negative number.");
        }
    }
}
