using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlanner.Business.Domain
{
    public class MealPlanDetailed : MealPlan
    {
        public IEnumerable<ScheduledMeal> Meals { get; set; }
    }
}
