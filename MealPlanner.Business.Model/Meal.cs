using System;

namespace MealPlanner.Business.Model
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //[MaxLength(500)]
        public string Description { get; set; }
        //[Required]
        public Guid OwnerId { get; set; }
        //[Required]
        public MealType MealType { get; set; }
    }
}
