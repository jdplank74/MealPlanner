using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.Database.Entity
{
    public class User : EntityBase
    {
        [Required]
        public Guid UniqueId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Firstname { get; set; }
        [MaxLength(50)]
        [Required]
        public string Lastname { get; set; }
        [MaxLength(50)]
        public string Middlename { get; set; }
        [MaxLength(254)]
        [Required]
        public string Email { get; set; }
        [MaxLength(254)]
        [Required]
        public string Username { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }
        public virtual ICollection<MealPlan> MealPlans { get; set; }

    }
}
