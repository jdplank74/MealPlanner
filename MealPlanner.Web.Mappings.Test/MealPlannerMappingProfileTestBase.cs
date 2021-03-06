﻿using Domain = MealPlanner.Business.Domain;
using Model = MealPlanner.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlanner.Web.Mappings.Test
{
    public class MealPlannerMappingProfileTestBase
    {

        public Domain.Meal GetMealDomainModel()
        {
            Domain.Meal meal = new Domain.Meal()
            {
                Id = 45,
                Name = "Eggs and Toast",
                Description = "Eggs and Toast with some butter",
                MealType = Domain.MealType.Breakfast,
                OwnerId = Guid.NewGuid()
            };

            return meal;
        }

        public Model.Meal GetMealModel()
        {
            Model.Meal meal = new Model.Meal()
            {
                Id = 35,
                Name = "Eggs and Toast",
                Description = "Eggs and Toast with some butter",
                MealType = "BREAKFAST",
                OwnerId = Guid.NewGuid()
            };

            return meal;
        }

        public Domain.MealPlan GetMealPlanDomainModel()
        {
            Domain.MealPlan mealPlan = new Domain.MealPlan()
            {
                Description = "A meal plan Description",
                Name = "A meal plan",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Id = 5,
                OwnerId = Guid.NewGuid()
            };
            return mealPlan;
        }

        public Model.MealPlan GetMealPlanLightModel()
        {
            Model.MealPlan mealPlan = new Model.MealPlan()
            {
                Description = "A meal plan Description",
                Name = "A meal plan",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Id = 5,
                OwnerId = Guid.NewGuid()
            };
            return mealPlan;
        }

        public Model.MealPlan GetMealPlanModel()
        {
            Model.MealPlan mealPlan = new Model.MealPlan()
            {
                Description = "A meal plan Description",
                Name = "A meal plan",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Id = 5,
                OwnerId = Guid.NewGuid()
            };
            mealPlan.Meals = new List<Model.ScheduledMeal>()
            {
                GetScheduledMealModel(mealPlan)
            };
            return mealPlan;
        }

        public Domain.MealPlanDetailed GetMealPlanDetailedDomainModel()
        {
            Domain.MealPlanDetailed mealPlan = new Domain.MealPlanDetailed()
            {
                Description = "A meal plan Description",
                Name = "A meal plan",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Id = 5,
                OwnerId = Guid.NewGuid()
            };
            mealPlan.Meals = new List<Domain.ScheduledMeal>()
            {
                GetScheduledMealDomainModel(mealPlan)
            };
            return mealPlan;
        }

        public Domain.ScheduledMeal GetScheduledMealDomainModel(Domain.MealPlan mealPlan)
        {
            Domain.ScheduledMeal meal = new Domain.ScheduledMeal()
            {
                Id = 87,
                MealPlan = mealPlan,
                Meal = GetMealDomainModel(),
                ScheduledDateTime = DateTime.Now
            };
            return meal;
        }

        public Model.ScheduledMeal GetScheduledMealModel(Model.MealPlan mealPlan)
        {
            Model.ScheduledMeal meal = new Model.ScheduledMeal()
            {
                Id = 87,
                MealPlanId = mealPlan.Id,
                Meal = GetMealModel(),
                ScheduledDateTime = DateTime.Now
            };
            return meal;
        }
    }
}
