using FluentValidation;
using MealPlanner.Web.Model;

namespace MealPlanner.Web.Api
{
    public class MealValidator : AbstractValidator<Meal>
    {
        public MealValidator()
        {
            RuleFor(m => m.Name).NotEmpty().MinimumLength(1).MaximumLength(80);
            RuleFor(m => m.Description).NotEmpty().MinimumLength(1).MaximumLength(500);
            RuleFor(m => m.MealType).Custom((mt, ctx) =>
            {
                if(!MealType.IsValidMealType(mt))
                {
                    ctx.AddFailure($"{mt} is not a valid MealType");
                }
            });
        }
    }
}
