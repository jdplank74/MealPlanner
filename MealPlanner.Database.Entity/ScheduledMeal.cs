using System;
using System.ComponentModel.DataAnnotations;

namespace MealPlanner.Database.Entity
{
    public class ScheduledMeal : EntityBase
    {
        [Required]
        public DateTime ScheduledDateTime { get; set; }
        [Required]
        public virtual int MealId { get; set; }
        public virtual Meal Meal { get; set; }
        [Required]
        public int MealPlanId { get; set; }
        public virtual MealPlan MealPlan { get; set; }
    }
}
