using MealPlanner.Business.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlanner.Business.Component
{
    public interface IMealPlannerComponent
    {
        IEnumerable<MealPlan> GetMealPlans(Guid userId);
        IList<ScheduledMeal> GetScheduledMeals(int mealPlanId);
        Domain.MealPlan CreateMealPlan(Domain.MealPlan mealPlan);
        void UpdateMealPlan(Domain.MealPlan mealPlan);
        IEnumerable<Domain.Meal> GetMeals(Guid userId);
    }
}
