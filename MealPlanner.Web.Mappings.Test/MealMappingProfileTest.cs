using Domain = MealPlanner.Business.Domain;
using MealPlanner.Web.Mappings;
using Model = MealPlanner.Web.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities.Mapper;

namespace MealPlanner.Web.Mappings.Test
{
    [TestClass]
    public class MealMappingProfileTest : MealPlannerMappingProfileTestBase
    {
        private IMappingHelper _mapper = new MappingHelper(new MealPlannerModelMappingConfigurationProvider());

        [TestMethod]
        public void MapMealDomainModeltoMealModel()
        {
            // Arrange
            Domain.Meal mealDomainModel = GetMealDomainModel();

            // Act
            Model.Meal mealModel = _mapper.Map<Model.Meal>(mealDomainModel);
            
            // Assert
            Assert.AreEqual(mealDomainModel.Id, mealModel.Id);
            Assert.AreEqual(mealDomainModel.Description,mealModel.Description);
            Assert.AreEqual(mealDomainModel.Name,mealModel.Name);
            Assert.AreEqual(mealDomainModel.OwnerId,mealModel.OwnerId);
            Assert.AreEqual(mealDomainModel.MealType.ToString(),mealModel.MealType);
        }

        [TestMethod]
        public void MapMealModeltoMealDomainModel()
        {
            // Arrange
            Model.Meal mealModel = GetMealModel();

            // Act
            Domain.Meal mealDomainModel = _mapper.Map<Domain.Meal>(mealModel);

            // Assert
            Assert.AreEqual(mealModel.Id, mealDomainModel.Id);
            Assert.AreEqual(mealModel.Description, mealDomainModel.Description);
            Assert.AreEqual(mealModel.Name, mealDomainModel.Name);
            Assert.AreEqual(mealModel.OwnerId, mealDomainModel.OwnerId);
            Assert.IsTrue(mealModel.MealType.Equals(mealDomainModel.MealType.ToString(),StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
