using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain = MealPlanner.Business.Domain;
using MealPlanner.Web.Mappings;
using Model = MealPlanner.Web.Model;
using System;
using System.Linq;
using Utilities.Mapper;

namespace MealPlanner.Web.Mappings.Test
{
    [TestClass]
    public class MealPlannerMappingProfileTest : MealPlannerMappingProfileTestBase
    {
        private IMappingConfigurationProvider mappingConfigProvider = new MealPlannerModelMappingConfigurationProvider();

        [TestMethod]
        public void MapMealPlanDetailedDomainToMealPlanModel()
        {
            // Arrange
            IMappingHelper mapper = new MappingHelper(mappingConfigProvider);
            Domain.MealPlanDetailed mealPlanDomainModel = GetMealPlanDetailedDomainModel();

            // Act
            Model.MealPlan mealPlanModel = mapper.Map<Model.MealPlan>(mealPlanDomainModel);

            // Assert
            Assert.AreEqual(mealPlanDomainModel.Id, mealPlanModel.Id);
            Assert.AreEqual(mealPlanDomainModel.Description, mealPlanModel.Description);
            Assert.AreEqual(mealPlanDomainModel.Name, mealPlanModel.Name);
            Assert.AreEqual(mealPlanDomainModel.StartDate, mealPlanModel.StartDate);
            Assert.AreEqual(mealPlanDomainModel.EndDate, mealPlanModel.EndDate);
            Assert.AreEqual(mealPlanDomainModel.OwnerId, mealPlanModel.OwnerId);
            Assert.IsTrue(mealPlanModel.Meals.Any());
            Assert.AreEqual(mealPlanDomainModel.Meals.Count(), mealPlanModel.Meals.Count());
        }

        [TestMethod]
        public void MapMealPlanModelToMealPlanDetailedDomainModel()
        {
            // Arrange
            IMappingHelper mapper = new MappingHelper(mappingConfigProvider);
            Model.MealPlan mealPlanModel = GetMealPlanModel();

            // Act
            Domain.MealPlanDetailed mealPlanDomainModel = mapper.Map<Domain.MealPlanDetailed>(mealPlanModel);

            // Assert
            Assert.AreEqual(mealPlanModel.Id, mealPlanDomainModel.Id);
            Assert.AreEqual(mealPlanModel.Description, mealPlanDomainModel.Description);
            Assert.AreEqual(mealPlanModel.Name, mealPlanDomainModel.Name);
            Assert.AreEqual(mealPlanModel.StartDate, mealPlanDomainModel.StartDate);
            Assert.AreEqual(mealPlanModel.EndDate, mealPlanDomainModel.EndDate);
            Assert.AreEqual(mealPlanModel.OwnerId, mealPlanDomainModel.OwnerId);
            Assert.IsTrue(mealPlanDomainModel.Meals.Any());
            Assert.AreEqual(mealPlanModel.Meals.Count(), mealPlanDomainModel.Meals.Count());
        }
    }
}
