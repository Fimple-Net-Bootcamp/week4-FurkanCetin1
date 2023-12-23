using FluentValidation;
using Week03.Models;

namespace Week03.FluentValidators
{
    public class FoodValidator : AbstractValidator<Food>
    {
        public FoodValidator()
        {
            RuleFor(food => food.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");

            RuleFor(food => food.Type)
                .NotEmpty().WithMessage("Type is required.")
                .Length(2, 50).WithMessage("Type must be between 2 and 50 characters.");
        }
    }
}
