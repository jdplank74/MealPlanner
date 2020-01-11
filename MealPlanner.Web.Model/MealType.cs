using System;
using System.Collections.Generic;
using System.Linq;


namespace MealPlanner.Web.Model
{
    public static class MealType
    {
        public static readonly List<string> ValidMealType = new List<string>() { "Breakfast", "Lunch", "Dinner", "Snack" };
        public static bool IsValidMealType(string mealTypeStr)
        {
            return ValidMealType.Any(mt => mt.Equals(mealTypeStr, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
