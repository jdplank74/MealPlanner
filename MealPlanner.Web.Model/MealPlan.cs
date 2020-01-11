using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlanner.Web.Model
{
    public class MealPlan : MealPlanLight
    {
        public IEnumerable<ScheduledMeal> Meals { get; set; }
    }
}
