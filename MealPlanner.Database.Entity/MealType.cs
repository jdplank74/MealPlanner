using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MealPlanner.Database.Entity
{
    public class MealType : EntityBase
    {
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
        [MaxLength(30)]
        [Required]
        public string Code { get; set; }
        [MaxLength(80)]
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }
    }
}
