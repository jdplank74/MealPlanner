using MealPlanner.Database.Entity;
using System;
using System.Collections.Generic;

namespace MealPlanner.DataAccess.Repository
{
    public interface IMealPlannerRepository
    {
        IEnumerable<MealPlan> GetMealPlansByUser(Guid userId);
        MealPlan GetMealPlanById(int mealPlanId);
        IList<ScheduledMeal> GetScheduledMeals(int mealPlanId);
        MealPlan AddMealPlan(MealPlan mealPlan);
        void UpdateMealPlan(MealPlan mealPlan);
        User GetUser(Guid userId);
        IList<Meal> GetMeals(Guid userId);
    }
}
