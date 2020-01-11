using Model = MealPlanner.Business.Domain;
using Entity = MealPlanner.Database.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MealPlanner.Mapper.Test
{
    [TestClass]
    public class MealPlanDetailedMappingProfileTest : MealPlannerMappingTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
        }

        public MealPlanDetailedMappingProfileTest() : base()
        {
        }

        [TestMethod]
        public void MapMealPlanEntityToMealPlanDetailsModel()
        {
            // Arrange
            Entity.MealPlan mealPlanEntity = GetMealPlanEntity();

            // Act
            Model.MealPlanDetailed mealPlanModel = _mapper.Map<Model.MealPlanDetailed>(mealPlanEntity);

            // Assert
            Assert.AreEqual(mealPlanEntity.Id, mealPlanModel.Id);
            Assert.AreEqual(mealPlanEntity.Name, mealPlanModel.Name);
            Assert.AreEqual(mealPlanEntity.Description, mealPlanModel.Description);
            Assert.AreEqual(mealPlanEntity.StartDate, mealPlanModel.StartDate);
            Assert.AreEqual(mealPlanEntity.EndDate, mealPlanModel.EndDate);
            Assert.AreEqual(mealPlanEntity.Owner.UniqueId, mealPlanModel.OwnerId);
            Assert.AreEqual(mealPlanEntity.Meals.Count(), mealPlanModel.Meals.Count());
        }

        [TestMethod]
        public void MapMealPlanModelToMealPlanEntity()
        {
            // Arrange
            Model.MealPlanDetailed mealPlanModel = GetMealPlanDetailedModel();

            // Act
            Entity.MealPlan mealPlanEntity = _mapper.Map<Entity.MealPlan>(mealPlanModel);

            // Assert
            Assert.AreEqual(mealPlanModel.Id, mealPlanEntity.Id);
            Assert.AreEqual(mealPlanModel.Name, mealPlanEntity.Name);
            Assert.AreEqual(mealPlanModel.Description, mealPlanEntity.Description);
            Assert.AreEqual(mealPlanModel.StartDate, mealPlanEntity.StartDate);
            Assert.AreEqual(mealPlanModel.EndDate, mealPlanEntity.EndDate);
            Assert.AreEqual(mealPlanModel.OwnerId, mealPlanEntity.Owner.UniqueId);
            Assert.AreEqual(mealPlanModel.Meals.Count(), mealPlanEntity.Meals.Count());
        }

    }
}
