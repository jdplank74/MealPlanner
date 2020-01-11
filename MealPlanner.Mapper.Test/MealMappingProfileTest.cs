using AutoMapper;
using AutoMapper.Configuration;
using MealPlanner.Mapper;
using Model = MealPlanner.Business.Domain;
using Entity = MealPlanner.Database.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace MealPlanner.Mapper.Test
{
    [TestClass]
    public class MealMappingProfileTest : MealPlannerMappingTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
        }

        public MealMappingProfileTest() : base()
        {
        }

        [TestMethod]
        public void MapMealEntityToMealModelTest()
        {
            // Arrange
            Entity.Meal mealEntity = GetMealEntity();
            // Act
            Model.Meal mealModel = _mapper.Map<Model.Meal>(mealEntity);

            // Assert
            Assert.AreEqual(mealEntity.Name, mealModel.Name);
            Assert.AreEqual(mealEntity.Description, mealModel.Description);
            Assert.AreEqual(mealEntity.Owner.UniqueId, mealModel.OwnerId);
            Assert.AreEqual(mealEntity.Id, mealModel.Id);
            Assert.AreEqual(mealEntity.MealType.Code, mealModel.MealType.ToString());
        }

        [TestMethod]
        public void MapMealModelToMealEntityTest()
        {
            // Arrange
            Model.Meal mealModel = GetMealModel();
            
            // Act
            Entity.Meal mealEntity = _mapper.Map<Entity.Meal>(mealModel);

            // Assert
            Assert.AreEqual(mealModel.Name, mealEntity.Name);
            Assert.AreEqual(mealModel.Description, mealEntity.Description);
            Assert.AreEqual(mealModel.OwnerId, mealEntity.Owner.UniqueId);
            Assert.AreEqual(mealModel.Id, mealEntity.Id);
            Assert.AreEqual(mealModel.MealType.ToString(), mealEntity.MealType.Code);
        }
    }
}
