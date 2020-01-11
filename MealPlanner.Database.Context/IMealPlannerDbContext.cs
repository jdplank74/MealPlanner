using MealPlanner.Database.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MealPlanner.Database.Context
{
    public interface IMealPlannerDbContext
    {
        DbSet<Meal> Meals { get; set; }
        DbSet<MealPlan> MealPlans { get; set; }
        DbSet<MealType> MealTypes { get; set; }
        DbSet<ScheduledMeal> ScheduledMeals { get; set; }
        DbSet<User> Users { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
