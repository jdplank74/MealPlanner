using Domain = MealPlanner.Business.Domain;
using MealPlanner.Business.Component;
using MealPlanner.Mappings;
using MealPlanner.Web.Api.Helpers;
using MealPlanner.Web.Mappings;
using Model = MealPlanner.Web.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MealPlanner.Web.Api.Test.Helpers
{
    [TestClass]
    public class MealPlannerHelperTest
    {
        [TestMethod]
        public void GetMealPlansTest()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            var componentMock = new Mock<IMealPlannerComponent>();
            componentMock.Setup(m => m.GetMealPlans(It.IsAny<Guid>())).Returns(new List<Domain.MealPlan>() { GetMealPlanDomainModel(userId) });

            MealPlannerModelMapper mapper = new MealPlannerModelMapper(new MealPlannerModelMappingConfigurationProvider());
            IMealPlannerHelper helper = new MealPlannerHelper(componentMock.Object, mapper);

            // Act
            var mealPlanList = helper.GetMealPlans(userId);

            // Assert
            Assert.AreEqual(1, mealPlanList.Count());
        }

        [TestMethod]
        public void GetMealPlansNoResultsTest()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            var componentMock = new Mock<IMealPlannerComponent>();
            componentMock.Setup(m => m.GetMealPlans(It.IsAny<Guid>())).Returns(new List<Domain.MealPlan>());

            MealPlannerModelMapper mapper = new MealPlannerModelMapper(new MealPlannerModelMappingConfigurationProvider());
            IMealPlannerHelper helper = new MealPlannerHelper(componentMock.Object, mapper);

            // Act
            var mealPlans = helper.GetMealPlans(userId);

            // Assert
            Assert.AreEqual(0, mealPlans.Count());
            componentMock.Verify(m => m.GetMealPlans(It.IsAny<Guid>()), Times.Once);
        }

        [TestMethod]
        public void GetScheduledMealsTest()
        {
            // Arrange
            Guid ownerId = Guid.NewGuid();
            var componentMock = new Mock<IMealPlannerComponent>();
            componentMock.Setup(m => m.GetScheduledMeals(It.IsAny<int>())).Returns(GetScheduledMealsDomainList(ownerId));

            MealPlannerModelMapper mapper = new MealPlannerModelMapper(new MealPlannerModelMappingConfigurationProvider());
            IMealPlannerHelper helper = new MealPlannerHelper(componentMock.Object, mapper);

            // Act 
            var scheduledMeals = helper.GetScheduledMeals(5);

            // Assert
            Assert.AreEqual(1, scheduledMeals.Count());
        }

        [TestMethod]
        public void GetScheduledMealsTestNotFound()
        {
            // Arrange
            var componentMock = new Mock<IMealPlannerComponent>();
            componentMock.Setup(m => m.GetScheduledMeals(It.IsAny<int>())).Returns(new List<Domain.ScheduledMeal>());

            MealPlannerModelMapper mapper = new MealPlannerModelMapper(new MealPlannerModelMappingConfigurationProvider());
            IMealPlannerHelper helper = new MealPlannerHelper(componentMock.Object, mapper);

            // Act 
            var scheduledMeals = helper.GetScheduledMeals(5);

            // Assert
            Assert.AreEqual(0, scheduledMeals.Count());
            componentMock.Verify(m => m.GetScheduledMeals(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void CreateMealPlanTest()
        {
            // Arrange
            var mapper = new MealPlannerModelMapper(new MealPlannerModelMappingConfigurationProvider());

            Model.MealPlanLight inMealPlanModel = GetMealPlanModelForCreate();
            Domain.MealPlan mealPlanDomain = GetMealPlanDomainModelForCreateMockReturn();

            var componentMock = new Mock<IMealPlannerComponent>();
            componentMock.Setup(m => m.CreateMealPlan(It.IsAny<Domain.MealPlan>())).Returns(mealPlanDomain);

            IMealPlannerHelper helper = new MealPlannerHelper(componentMock.Object, mapper);

            // Act
            var mealPlan = helper.CreateMealPlan(inMealPlanModel);

            // Assert
            Assert.AreEqual(mealPlanDomain.Id, mealPlan.Id);
            Assert.AreEqual(inMealPlanModel.Name, mealPlan.Name);
        }

        [TestMethod]
        public void UpdateMealPlanTest()
        {
            // Arrange
            var mapper = new MealPlannerModelMapper(new MealPlannerModelMappingConfigurationProvider());

            Model.MealPlanLight inMealPlanModel = GetMealPlanModelForUpdate();
            
            var componentMock = new Mock<IMealPlannerComponent>();
            componentMock.Setup(m => m.UpdateMealPlan(It.IsAny<Domain.MealPlan>()));

            IMealPlannerHelper helper = new MealPlannerHelper(componentMock.Object, mapper);

            // Act
            helper.UpdateMealPlan(inMealPlanModel);

            // Assert
            componentMock.Verify(m => m.UpdateMealPlan(It.IsAny<Domain.MealPlan>()),Times.Once);
        }

        [TestMethod]
        public void GetMealsTest()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            MealPlannerModelMapper mapper = new MealPlannerModelMapper(new MealPlannerModelMappingConfigurationProvider());

            var componentMock = new Mock<IMealPlannerComponent>();
            componentMock.Setup(m => m.GetMeals(It.IsAny<Guid>())).Returns(GetMeals(userId));

            IMealPlannerHelper helper = new MealPlannerHelper(componentMock.Object, mapper);

            // Act
            var meals = helper.GetMeals(userId);

            // Assert
            componentMock.Verify(m => m.GetMeals(It.IsAny<Guid>()), Times.Once);

            Assert.AreEqual(2, meals.Count());
        }

        public static Domain.MealPlan GetMealPlanDomainModel(Guid ownerId)
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

        public static List<Domain.ScheduledMeal> GetScheduledMealsDomainList(Guid ownerId)
        {
            Domain.ScheduledMeal scheduledMeal = new Domain.ScheduledMeal()
            {
                Id = 86,
                Meal = new Domain.Meal()
                {
                    Id = 45,
                    Description = "Ham and Cheese Sandwich",
                    MealType = Domain.MealType.Lunch,
                    Name = "Ham and Cheese Sandwich",
                    OwnerId = Guid.NewGuid()
                },
                MealPlan = GetMealPlanDomainModel(ownerId)
            };
            return new List<Domain.ScheduledMeal>() { scheduledMeal };
        }

        public Model.MealPlanLight GetMealPlanModelForCreate()
        {
            Model.MealPlanLight mealPlanModel = new Model.MealPlanLight()
            {
                Name = "Family Meal Plan",
                Description = "Mean plan for the family",
                StartDate = new DateTime(2019, 8, 1),
                EndDate = new DateTime(2019, 8, 31),
                OwnerId = Guid.NewGuid()
            };

            return mealPlanModel;
        }

        public Model.MealPlanLight GetMealPlanModelForUpdate()
        {
            Model.MealPlanLight mealPlanModel = new Model.MealPlanLight()
            {
                Id = 98,
                Name = "Family Meal Plan",
                Description = "Mean plan for the family",
                StartDate = new DateTime(2019, 8, 1),
                EndDate = new DateTime(2019, 8, 31),
                OwnerId = Guid.NewGuid()
            };

            return mealPlanModel;
        }

        public Domain.MealPlan GetMealPlanDomainModelForCreateMockReturn()
        {
            Domain.MealPlan mealPlanDomain = new Domain.MealPlan()
            {
                Id = 56,
                Name = "Family Meal Plan",
                Description = "Mean plan for the family",
                StartDate = new DateTime(2019, 8, 1),
                EndDate = new DateTime(2019, 8, 31),
                OwnerId = Guid.NewGuid()
            };

            return mealPlanDomain;
        }

        public List<Domain.Meal> GetMeals(Guid userId)
        {
            List<Domain.Meal> meals = new List<Domain.Meal>()
            {
                new Domain.Meal()
                {
                    Id = 76,
                    Name = "P B and J",
                    Description = "Peanut butter and jelly",
                    MealType = Domain.MealType.Lunch,
                    OwnerId = userId
                },
                new Domain.Meal()
                {
                    Id = 76,
                    Name = "Bagel Thin And Eggs",
                    Description = "2 Bagel thins and 2 eggs",
                    MealType = Domain.MealType.Breakfast,
                    OwnerId = userId
                }
            };

            return meals;
        }
    }
}
