using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MealPlanner.Database.Entity
{
    public class Meal : EntityBase
    {
        [MaxLength(80)]
        [Required]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public int OwnerId { get; set; }
        public virtual User Owner { get; set; }
        [Required]
        public int MealTypeId { get; set; }
        public virtual MealType MealType { get; set; }
        public virtual ICollection<ScheduledMeal> ScheduledMeals { get; set; }
    }
}
