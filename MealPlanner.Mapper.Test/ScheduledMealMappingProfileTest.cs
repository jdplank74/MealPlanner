using Model = MealPlanner.Business.Domain;
using Entity = MealPlanner.Database.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MealPlanner.Mapper.Test
{
    [TestClass]
    public class ScheduledMealMappingProfileTest : MealPlannerMappingTestBase
    {
        public ScheduledMealMappingProfileTest() : base()
        {

        }

        [TestMethod]
        public void MapScheduledMealEntityToScheduledMealModel()
        {
            // Arrange
            Entity.MealPlan mealPlanEntity = GetMealPlanEntity();
            Entity.ScheduledMeal schedMealEntity = GetScheduledMealEntity(mealPlanEntity);

            // Act
            Model.ScheduledMeal schedMealModel = _mapper.Map<Model.ScheduledMeal>(schedMealEntity);

            // Assert
            Assert.AreEqual(schedMealEntity.Id, schedMealModel.Id);
            Assert.AreEqual(schedMealEntity.ScheduledDateTime, schedMealModel.ScheduledDateTime);
            Assert.IsNotNull(schedMealModel.Meal);
            Assert.IsNotNull(schedMealModel.MealPlan);
        }

        [TestMethod]
        public void MapScheduledMealModelToScheduledMealEntity()
        {
            // Arrange
            Model.MealPlan mealPlanModel = GetMealPlanModel();
            Model.ScheduledMeal schedMealModel = GetScheduledMealModel(mealPlanModel);

            // Act
            Entity.ScheduledMeal schedMealEntity = _mapper.Map<Entity.ScheduledMeal>(schedMealModel);

            // Assert
            Assert.AreEqual(schedMealModel.Id, schedMealEntity.Id);
            Assert.AreEqual(schedMealModel.ScheduledDateTime, schedMealEntity.ScheduledDateTime);
            Assert.IsNotNull(schedMealModel.Meal);
            Assert.IsNotNull(schedMealModel.MealPlan);
        }
    }
}
