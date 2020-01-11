using Domain = MealPlanner.Business.Domain;
using MealPlanner.Business.Component;
using MealPlanner.Web.Api.Controllers;
using MealPlanner.Web.Api.Helpers;
using MealPlanner.Web.Mappings;
using Model = MealPlanner.Web.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MealPlanner.Web.Api.Test.Controllers
{
    [TestClass]
    public class MealPlansControllerTest
    {
        [TestMethod]
        public void GetMealPlansTest()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            var helperMock = new Mock<IMealPlannerHelper>();
            helperMock.Setup(m => m.GetMealPlans(It.IsAny<Guid>())).Returns(new List<Model.MealPlanLight>() { GetMealPlanModel(userId) });

            MealPlansController controller = new MealPlansController(helperMock.Object);

            // Act
            IActionResult actionResult = controller.GetMealPlans(userId);

            // Assert
            helperMock.Verify(m => m.GetMealPlans(It.IsAny<Guid>()), Times.Once);
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
            var okObjectResult = actionResult as OkObjectResult;
            var mealPlanList = okObjectResult.Value as IEnumerable<Model.MealPlanLight>;
            Assert.AreEqual(1, mealPlanList.Count());
        }

        [TestMethod]
        public void GetMealPlansNotFoundTest()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            var helperMock = new Mock<IMealPlannerHelper>();
            helperMock.Setup(m => m.GetMealPlans(It.IsAny<Guid>())).Returns(new List<Model.MealPlanLight>());

            MealPlansController controller = new MealPlansController(helperMock.Object);

            // Act
            IActionResult actionResult = controller.GetMealPlans(userId);

            // Assert
            helperMock.Verify(m => m.GetMealPlans(It.IsAny<Guid>()), Times.Once);
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetScheduledMealsTest()
        {
            // Arrange
            Guid ownerId = Guid.NewGuid();
            var helperMock = new Mock<IMealPlannerHelper>();
            helperMock.Setup(m => m.GetScheduledMeals(It.IsAny<int>())).Returns(GetScheduledMealsModelList(ownerId));

            MealPlansController controller = new MealPlansController(helperMock.Object);

            // Act 
            IActionResult actionResult = controller.GetScheduledMeals(5);

            // Assert
            helperMock.Verify(m => m.GetScheduledMeals(It.IsAny<int>()), Times.Once);
            var okObjectResult = actionResult as OkObjectResult;
            var scheduledMealList = okObjectResult.Value as IEnumerable<Model.ScheduledMeal>;
            Assert.AreEqual(1, scheduledMealList.Count());
        }

        [TestMethod]
        public void GetScheduledMealsTestNotFound()
        {
            // Arrange
            Guid ownerId = Guid.NewGuid();
            var helperMock = new Mock<IMealPlannerHelper>();
            helperMock.Setup(m => m.GetScheduledMeals(It.IsAny<int>())).Returns(new List<Model.ScheduledMeal>());

            MealPlansController controller = new MealPlansController(helperMock.Object);

            // Act 
            IActionResult actionResult = controller.GetScheduledMeals(5);

            // Assert
            helperMock.Verify(m => m.GetScheduledMeals(It.IsAny<int>()), Times.Once);
            Assert.IsInstanceOfType(actionResult,typeof(NotFoundResult));
        }

        [TestMethod]
        public void CreateMealPlanTest()
        {
            // Arrange
            Model.MealPlanLight inMealPlanModel = GetMealPlanModelForCreate();
            Model.MealPlanLight mealPlanModel = GetMealPlanModelForCreateMockReturn();

            var helperMock = new Mock<IMealPlannerHelper>();
            helperMock.Setup(m => m.CreateMealPlan(It.IsAny<Model.MealPlanLight>())).Returns(mealPlanModel);

            MealPlansController controller = new MealPlansController(helperMock.Object);

            // Act
            IActionResult actionResult = controller.CreateMealPlan(inMealPlanModel);

            // Assert
            helperMock.Verify(m => m.CreateMealPlan(It.IsAny<Model.MealPlanLight>()), Times.Once);
            var createdResult = actionResult as CreatedResult;
            Assert.IsNotNull(createdResult);
            
            var outMealPlanModel = createdResult.Value as Model.MealPlanLight;
            Assert.AreEqual(mealPlanModel.Id,outMealPlanModel.Id);
            Assert.AreEqual(outMealPlanModel.Id.ToString(),createdResult.Location);
            Assert.AreEqual(inMealPlanModel.Name, outMealPlanModel.Name);
            
        }

        [TestMethod]
        public void UpdateMealPlanTest()
        {
            // Arrange
            Model.MealPlanLight inMealPlanModel = GetMealPlanModelForUpdate();
            
            var helperMock = new Mock<IMealPlannerHelper>();
            helperMock.Setup(m => m.UpdateMealPlan(It.IsAny<Model.MealPlanLight>()));

            MealPlansController controller = new MealPlansController(helperMock.Object);

            // Act
            IActionResult actionResult = controller.UpdateMealPlan(inMealPlanModel);

            // Assert
            helperMock.Verify(m => m.UpdateMealPlan(It.IsAny<Model.MealPlanLight>()), Times.Once);
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public void UpdateMealPlanTestThrowException()
        {
            // Arrange
            Model.MealPlanLight inMealPlanModel = GetMealPlanModelForUpdate();

            var helperMock = new Mock<IMealPlannerHelper>();
            helperMock.Setup(m => m.UpdateMealPlan(It.IsAny<Model.MealPlanLight>())).Throws<Exception>();

            MealPlansController controller = new MealPlansController(helperMock.Object);

            // Act and Assert
            Assert.ThrowsException<Exception>(() => controller.UpdateMealPlan(inMealPlanModel));
            helperMock.Verify(m => m.UpdateMealPlan(It.IsAny<Model.MealPlanLight>()), Times.Once);
        }


        public static Model.MealPlanLight GetMealPlanModel(Guid ownerId)
        {
            Model.MealPlanLight mealPlan = new Model.MealPlanLight()
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

        public static List<Model.ScheduledMeal> GetScheduledMealsModelList(Guid ownerId)
        {
            Model.ScheduledMeal scheduledMeal = new Model.ScheduledMeal()
            {
                Id = 86,
                Meal = new Model.Meal()
                {
                    Id = 45,
                    Description = "Ham and Cheese Sandwich",
                    MealType = "Lunch",
                    Name = "Ham and Cheese Sandwich",
                    OwnerId = Guid.NewGuid()
                },
                MealPlanId = GetMealPlanModel(ownerId).Id
            };

            return new List<Model.ScheduledMeal>() { scheduledMeal };
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
                Id = 55,
                Name = "Family Meal Plan",
                Description = "Mean plan for the family",
                StartDate = new DateTime(2019, 8, 1),
                EndDate = new DateTime(2019, 8, 31),
                OwnerId = Guid.NewGuid()
            };

            return mealPlanModel;
        }

        public Model.MealPlanLight GetMealPlanModelForCreateMockReturn()
        {
            Model.MealPlanLight mealPlanModel = new Model.MealPlanLight()
            {
                Id = 56,
                Name = "Family Meal Plan",
                Description = "Mean plan for the family",
                StartDate = new DateTime(2019, 8, 1),
                EndDate = new DateTime(2019, 8, 31),
                OwnerId = Guid.NewGuid()
            };

            return mealPlanModel;
        }
    }
}
