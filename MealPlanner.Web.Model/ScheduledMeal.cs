using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlanner.Web.Model
{
    public class ScheduledMeal
    {
        public int Id { get; set; }
        public int MealPlanId { get; set; }
        public Meal Meal { get; set; }
        public DateTime ScheduledDateTime { get; set; }
    }
}
