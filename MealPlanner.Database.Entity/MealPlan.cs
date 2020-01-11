using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MealPlanner.Database.Entity
{
    public class MealPlan : EntityBase
    {
        [MaxLength(80)]
        [Required]
        public string Name { get; set; }
        [MaxLength(500)]
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int OwnerId { get; set; }
        public virtual User Owner { get; set; }
        public virtual ICollection<ScheduledMeal> Meals { get; set; }
    }
}
