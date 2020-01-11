using AutoMapper;
using Model = MealPlanner.Business.Domain;
using Entity = MealPlanner.Database.Entity;
using MealPlanner.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlanner.Mapper.Test
{
    public class MealPlannerMappingTestBase
    {

        protected IMapper _mapper;

        public MealPlannerMappingTestBase()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MealMappingProfile>();
                cfg.AddProfile<MealPlanMappingProfile>();
                cfg.AddProfile<ScheduledMealMappingProfile>();
                cfg.AddProfile<MealPlanDetailedMappingProfile>();
            });
            _mapper = config.CreateMapper();
        }
        public static Entity.Meal GetMealEntity()
        {
            return new Entity.Meal()
            {
                Id = 1,
                Description = "A Meal",
                Name = "Meal",
                Owner = GetOwnerEntity(),
                OwnerId = 1,
                MealType = GetMealTypeEntity(),
                MealTypeId = 1
            };
        }

        public static Entity.User GetOwnerEntity()
        {
            return new Entity.User()
            {
                Id = 1,
                Firstname = "John",
                Lastname = "Smith",
                Email = "jsmith@whatever.com",
                UniqueId = Guid.NewGuid(),
                Username = "jsmith",
            };
        }
        public static Entity.MealType GetMealTypeEntity()
        {
            return new Entity.MealType()
            {
                Id = 1,
                Code = "Breakfast",
                Name = "Bfast",
                IsActive = true,
                Description = "Morning Meal"
            };
        }

        public static Model.Meal GetMealModel()
        {
            return new Model.Meal()
            {
                Id = 1,
                Description = "A Meal",
                Name = "Meal",
                OwnerId = Guid.NewGuid(),
                MealType = Model.MealType.Breakfast,
            };
        }

        public static Entity.MealPlan GetMealPlanEntity()
        {
            var mealPlan = new Entity.MealPlan()
            {
                Id = 1,
                Description = "The Meal Plan of John",
                StartDate = new DateTime(2019, 1, 1),
                EndDate = new DateTime(2019, 1, 30),
                Name = "John's Meal Plan",
                Owner = GetOwnerEntity(),
                OwnerId = 1,
            };
            mealPlan.Meals = GetScheduledMealEntityList(mealPlan);

            return mealPlan;
        }

        public static Model.MealPlan GetMealPlanModel()
        {
            var mealPlan = new Model.MealPlan()
            {
                Id = 1,
                Description = "The Meal Plan of John",
                StartDate = new DateTime(2019, 1, 1),
                EndDate = new DateTime(2019, 1, 30),
                Name = "John's Meal Plan",
                OwnerId = Guid.NewGuid(),
            };

            return mealPlan;
        }

        public static Model.MealPlanDetailed GetMealPlanDetailedModel()
        {
            var mealPlan = new Model.MealPlanDetailed()
            {
                Id = 1,
                Description = "The Meal Plan of John",
                StartDate = new DateTime(2019, 1, 1),
                EndDate = new DateTime(2019, 1, 30),
                Name = "John's Meal Plan",
                OwnerId = Guid.NewGuid(),
            };
            mealPlan.Meals = GetScheduledMealModelList(mealPlan);

            return mealPlan;
        }


        public static List<Entity.ScheduledMeal> GetScheduledMealEntityList(Entity.MealPlan mealPlan)
        {
            return new List<Entity.ScheduledMeal>()
            {
                GetScheduledMealEntity(mealPlan)
            };
        }

        public static Entity.ScheduledMeal GetScheduledMealEntity(Entity.MealPlan mealPlan)
        {
            Entity.Meal meal = GetMealEntity();
            
            return new Entity.ScheduledMeal()
            {
                Id = 1,
                MealId = meal.Id,
                Meal = meal,
                MealPlanId = mealPlan.Id,
                MealPlan = mealPlan,
                ScheduledDateTime = new DateTime(2019,01,01),
            };
        }

        public static List<Model.ScheduledMeal> GetScheduledMealModelList(Model.MealPlanDetailed mealPlan)
        {
            return new List<Model.ScheduledMeal>()
            {
                GetScheduledMealModel(mealPlan)
            };
        }

        public static Model.ScheduledMeal GetScheduledMealModel(Model.MealPlan mealPlan)
        {
            Model.Meal meal = GetMealModel();
            
            return new Model.ScheduledMeal()
            {
                Id = 1,
                Meal = meal,
                MealPlan = mealPlan,
                ScheduledDateTime = new DateTime(2019, 01, 01)
            };
        }
    }
}
