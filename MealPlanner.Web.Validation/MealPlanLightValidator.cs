using FluentValidation;
using MealPlanner.Web.Model;

namespace MealPlanner.Web.Validation
{
    public class MealPlanLightValidator : AbstractValidator<MealPlanLight>
    {
        public MealPlanLightValidator()
        {
            RuleFor(m => m.Name).NotEmpty().MinimumLength(1).MaximumLength(80);
            RuleFor(m => m.Description).NotEmpty().MinimumLength(1).MaximumLength(500);
            RuleFor(m => m.StartDate).NotEmpty();
            RuleFor(m => m.EndDate).NotEmpty();
            RuleFor(m => m.OwnerId).NotEmpty();
        }
    }
}
