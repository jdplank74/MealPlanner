using MealPlanner.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlanner.Web.Api.Helpers
{
    public interface IMealPlannerHelper
    {
        IEnumerable<MealPlanLight> GetMealPlans(Guid userId);
        IList<ScheduledMeal> GetScheduledMeals(int mealPlanId);
        MealPlanLight CreateMealPlan(MealPlanLight mealPlan);
        void UpdateMealPlan(MealPlanLight mealPlan);
        IEnumerable<Meal> GetMeals(Guid userId);
        Meal CreateMeal(Meal meal);

    }
}
