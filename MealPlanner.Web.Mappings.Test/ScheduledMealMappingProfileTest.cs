using Domain = MealPlanner.Business.Domain;
using Model = MealPlanner.Web.Model;
using MealPlanner.Web.Mappings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities.Mapper;

namespace MealPlanner.Web.Mappings.Test
{
    [TestClass]
    public class ScheduledMealMappingProfileTest : MealPlannerMappingProfileTestBase
    {
        private IMappingHelper _mapper = new MappingHelper(new MealPlannerModelMappingConfigurationProvider());

        [TestMethod]
        public void MapScheduleMealDomainModeltoScheduledMealModel()
        {
            // Arrange
            Domain.ScheduledMeal scheduledMealDomainModel = GetScheduledMealDomainModel(GetMealPlanDomainModel());

            // Act
            Model.ScheduledMeal scheduledMealModel = _mapper.Map<Model.ScheduledMeal>(scheduledMealDomainModel);

            // Assert
            Assert.AreEqual(scheduledMealDomainModel.Id, scheduledMealModel.Id);
            Assert.IsNotNull(scheduledMealDomainModel.Meal);
            Assert.AreEqual(scheduledMealDomainModel.Meal.Name, scheduledMealModel.Meal.Name);
            Assert.IsNotNull(scheduledMealDomainModel.MealPlan);
            Assert.AreEqual(scheduledMealDomainModel.MealPlan.Id, scheduledMealModel.MealPlanId);
            Assert.AreEqual(scheduledMealDomainModel.ScheduledDateTime, scheduledMealModel.ScheduledDateTime);
        }

        [TestMethod]
        public void MapScheduledMealModeltoScheduledMealDomainModel()
        {
            // Arrange
            Model.ScheduledMeal scheduledMealModel = GetScheduledMealModel(GetMealPlanModel());

            // Act
            Domain.ScheduledMeal scheduledMealDomainModel = _mapper.Map<Domain.ScheduledMeal>(scheduledMealModel);

            // Assert
            Assert.AreEqual(scheduledMealModel.Id, scheduledMealDomainModel.Id);
            Assert.IsNotNull(scheduledMealModel.Meal);
            Assert.AreEqual(scheduledMealModel.Meal.Name, scheduledMealDomainModel.Meal.Name);
            Assert.AreEqual(scheduledMealModel.MealPlanId, scheduledMealDomainModel.MealPlan.Id);
            Assert.AreEqual(scheduledMealModel.ScheduledDateTime, scheduledMealDomainModel.ScheduledDateTime);
        }
    }
}
