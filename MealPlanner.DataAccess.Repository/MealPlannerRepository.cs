using MealPlanner.Database.Context;
using MealPlanner.Database.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MealPlanner.DataAccess.Repository
{
    public class MealPlannerRepository : IMealPlannerRepository
    {
        private readonly IMealPlannerDbContext _dbContext;
        public MealPlannerRepository(IMealPlannerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<MealPlan> GetMealPlansByUser(Guid userId)
        {
            var mealPlans = _dbContext.MealPlans.Where(mp => mp.Owner.UniqueId == userId)
                .Include(mp => mp.Owner);
                
            return mealPlans;
        }

        public IList<ScheduledMeal> GetScheduledMeals(int mealPlanId)
        {
            var meals = _dbContext.ScheduledMeals.Where(sm => sm.MealPlanId == mealPlanId)
                .Include(sm => sm.MealPlan).ThenInclude(o => o.Owner)
                .Include(sm => sm.Meal).ThenInclude(m => m.Owner)
                .Include(sm => sm.Meal).ThenInclude(m => m.MealType)
                .ToList();

            return meals;
        }

        public MealPlan AddMealPlan(MealPlan mealPlan)
        {
            _dbContext.MealPlans.Add(mealPlan);
            _dbContext.SaveChanges();
            return mealPlan;
        }

        public User GetUser(Guid userId)
        {
            var user = _dbContext.Users.Where(u => u.UniqueId == userId).FirstOrDefault();
            return user;
        }

        public void UpdateMealPlan(MealPlan mealPlan)
        {
            _dbContext.MealPlans.Update(mealPlan);
            _dbContext.SaveChanges();
        }

        public MealPlan GetMealPlanById(int mealPlanId)
        {
            var mealPlan = _dbContext.MealPlans.Where(mp => mp.Id == mealPlanId).FirstOrDefault();
            return mealPlan;
        }

        public IList<Meal> GetMeals(Guid userId)
        {
            var meals = _dbContext.Meals.Where(m => m.Owner.UniqueId == userId)
                .Include(m => m.MealType)
                .Include(m => m.Owner)
                .ToList();
            return meals;
        }
    }
}
