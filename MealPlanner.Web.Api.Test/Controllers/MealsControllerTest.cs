using MealPlanner.Web.Model;
using MealPlanner.Web.Api.Controllers;
using MealPlanner.Web.Api.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MealPlanner.Web.Api.Test.Controllers
{
    [TestClass]
    public class MealsControllerTest
    {
        [TestMethod]
        public void GetMealsTest()
        {
            // Arrange
            Guid userId = Guid.NewGuid();

            var helperMock = new Mock<IMealPlannerHelper>();
            helperMock.Setup(m => m.GetMeals(It.IsAny<Guid>())).Returns(GetMeals(userId));

            MealsController controller = new MealsController(helperMock.Object);

            // Act 
            IActionResult actionResult = controller.GetMeals(userId);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
            var okObjectResult = actionResult as OkObjectResult;
            var mealList = okObjectResult.Value as List<Meal>;
            Assert.AreEqual(2, mealList.Count());
        }

        [TestMethod]
        public void GetMealsTestNotFound()
        {
            // Arrange
            Guid userId = Guid.NewGuid();

            var helperMock = new Mock<IMealPlannerHelper>();
            helperMock.Setup(m => m.GetMeals(It.IsAny<Guid>())).Returns(new List<Meal>());

            MealsController controller = new MealsController(helperMock.Object);

            // Act 
            IActionResult actionResult = controller.GetMeals(userId);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetMealsTestThrowException()
        {
            // Arrange
            var helperMock = new Mock<IMealPlannerHelper>();
            helperMock.Setup(m => m.GetMeals(It.IsAny<Guid>())).Throws<Exception>();

            MealsController controller = new MealsController(helperMock.Object);

            // Act and Assert
            Assert.ThrowsException<Exception>(() => controller.GetMeals(Guid.NewGuid()));
        }

        [TestMethod]
        public void CreateMeal()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            Meal meal = GetMealForCreate(userId);

            var helperMock = new Mock<IMealPlannerHelper>();
            helperMock.Setup(m => m.CreateMeal(meal)).Returns(GetMealForCreate(userId));

            MealsController controller = new MealsController(helperMock.Object);

            // Act
            IActionResult actionResult = controller.CreateMeal(meal);

            // Assert
            var createdResult = actionResult as CreatedResult;
            Assert.IsNotNull(createdResult);
            var createdMeal = (Meal)createdResult.Value;
            Assert.IsNotNull(createdMeal);
        }

        private Meal GetMeal1(Guid userId)
        {
            return new Meal()
            {
                Id = 100,
                OwnerId = userId,
                Name = "Meal 1 Name",
                Description = "Meal 1 Description",
                MealType = "Breakfast"
            };
        }

        private Meal GetMeal2(Guid userId)
        {
            return new Meal()
            {
                Id = 200,
                OwnerId = userId,
                Name = "Meal 2 Name",
                Description = "Meal 2 Description",
                MealType = "Lunch"
            };
        }

        private Meal GetMealForCreate(Guid userId)
        {
            return new Meal()
            {
                Id = 0,
                OwnerId = userId,
                Name = "Meal to create",
                Description = "Meal being created",
                MealType = "Lunch"
            };
        }

        private Meal GetMealForCreateReturn(Guid userId)
        {
            return new Meal()
            {
                Id = 70,
                OwnerId = userId,
                Name = "Meal to create",
                Description = "Meal being created",
                MealType = "Lunch"
            };
        }

        private List<Meal> GetMeals(Guid userId)
        {
            List<Meal> mealList = new List<Meal>()
            {
                GetMeal1(userId),
                GetMeal2(userId)
            };

            return mealList;
        }
    }
}
