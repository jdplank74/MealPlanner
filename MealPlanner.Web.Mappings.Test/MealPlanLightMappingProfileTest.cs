using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain = MealPlanner.Business.Domain;
using MealPlanner.Web.Mappings;
using Model = MealPlanner.Web.Model;
using System;
using Utilities.Mapper;

namespace MealPlanner.Web.Mappings.Test
{
    [TestClass]
    public class MealPlanLightMappingProfileTest : MealPlannerMappingProfileTestBase
    {
        private IMappingConfigurationProvider mappingConfigProvider = new MealPlannerModelMappingConfigurationProvider();

        [TestMethod]
        public void MapMealPlanDomainToMealPlanLightModel()
        {
            // Arrange
            IMappingHelper mapper = new MappingHelper(mappingConfigProvider);
            Domain.MealPlan mealPlanDomainModel = GetMealPlanDomainModel();

            // Act
            Model.MealPlanLight mealPlanModel = mapper.Map<Model.MealPlanLight>(mealPlanDomainModel);

            // Assert
            Assert.AreEqual(mealPlanDomainModel.Id, mealPlanModel.Id);
            Assert.AreEqual(mealPlanDomainModel.Description, mealPlanModel.Description);
            Assert.AreEqual(mealPlanDomainModel.Name, mealPlanModel.Name);
            Assert.AreEqual(mealPlanDomainModel.StartDate, mealPlanModel.StartDate);
            Assert.AreEqual(mealPlanDomainModel.EndDate, mealPlanModel.EndDate);
            Assert.AreEqual(mealPlanDomainModel.OwnerId, mealPlanModel.OwnerId);
        }

        [TestMethod]
        public void MapMealPlanLightModelToMealPlanDomainModel()
        {
            // Arrange
            IMappingHelper mapper = new MappingHelper(mappingConfigProvider);
            Model.MealPlanLight mealPlanModel = GetMealPlanModel();

            // Act
            Domain.MealPlan mealPlanDomainModel = mapper.Map<Domain.MealPlan>(mealPlanModel);

            // Assert
            Assert.AreEqual(mealPlanModel.Id, mealPlanDomainModel.Id);
            Assert.AreEqual(mealPlanModel.Description, mealPlanDomainModel.Description);
            Assert.AreEqual(mealPlanModel.Name, mealPlanDomainModel.Name);
            Assert.AreEqual(mealPlanModel.StartDate, mealPlanDomainModel.StartDate);
            Assert.AreEqual(mealPlanModel.EndDate, mealPlanDomainModel.EndDate);
            Assert.AreEqual(mealPlanModel.OwnerId, mealPlanDomainModel.OwnerId);
        }
    }
}
