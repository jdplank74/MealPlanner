using System;

namespace MealPlanner.Web.Model
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid OwnerId { get; set; }
        public string MealType { get; set; }
    }
}
