using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlanner.Business.Model
{
    public class ScheduledMeal
    {
        public int Id { get; set; }
        public MealPlan MealPlan { get; set; }
        public Meal Meal { get; set; }
        public DateTime ScheduledDateTime { get; set; }
    }
}
