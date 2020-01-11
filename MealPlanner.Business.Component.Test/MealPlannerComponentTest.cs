using MealPlanner.Business.Component;
using Domain = MealPlanner.Business.Domain;
using MealPlanner.DataAccess.Repository;
using Entity = MealPlanner.Database.Entity;
using MealPlanner.Mappings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Mapper;

namespace MealPlanner.Business.Component.Test
{
    [TestClass]
    public class MealPlannerComponentTest
    {
        private Mock<IMealPlannerRepository> _repoMock;
        private MealPlannerDomainMappingConfigurationProvider _mappingConfigProvider;

        public MealPlannerComponentTest()
        {
            _mappingConfigProvider = new MealPlannerDomainMappingConfigurationProvider();
        }

        [TestInitialize]
        public void Initialize()
        {
            _repoMock = new Mock<IMealPlannerRepository>();
        }

        [TestMethod]
        public void GetMealPlans()
        {
            // Arrange
            MealPlannerDomainMapper mapper = new MealPlannerDomainMapper(_mappingConfigProvider);
            var userId = Guid.NewGuid();
            _repoMock.Setup(m => m.GetMealPlansByUser(userId)).Returns(GetMealPlanList(userId));
            IMealPlannerComponent component = new MealPlannerComponent(_repoMock.Object, mapper);

            // Act
            var mealPlans = component.GetMealPlans(userId);

            // Assert
            _repoMock.Verify(m => m.GetMealPlansByUser(userId), Times.Once);
            Assert.IsTrue(mealPlans != null);
            Assert.AreEqual(1, mealPlans.Count());
        }

        [TestMethod]
        public void GetScheduledMeals()
        {
            // Arrange
            MealPlannerDomainMapper mapper = new MealPlannerDomainMapper(_mappingConfigProvider);

            int mealPlanId = 1;
            _repoMock.Setup(m => m.GetScheduledMeals(mealPlanId))
                .Returns(GetScheduledMealEntityList(GetMealPlanEntity(Guid.NewGuid())));
            IMealPlannerComponent component = new MealPlannerComponent(_repoMock.Object, mapper);
            // Act
            var scheduledMeals = component.GetScheduledMeals(1);

            // Assert
            _repoMock.Verify(m => m.GetScheduledMeals(mealPlanId), Times.Once);
            Assert.IsTrue(scheduledMeals != null);
            Assert.AreEqual(1, scheduledMeals.Count());
        }
        
        [TestMethod]
        public void CreateMealPlan()
        {
            // Arrange
            MealPlannerDomainMapper mapper = new MealPlannerDomainMapper(new MealPlannerDomainMappingConfigurationProvider());
            Guid userId = Guid.NewGuid();
            var mealPlanEntity = GetMealPlanEntity(userId);
            var mealPlanDomainModel = GetMealPlanDomainModel(userId);
            var user = GetOwnerEntity(userId);

            _repoMock.Setup(m => m.AddMealPlan(It.IsAny<Entity.MealPlan>())).Returns(mealPlanEntity);
            _repoMock.Setup(m => m.GetUser(It.IsAny<Guid>())).Returns(user);

            IMealPlannerComponent component = new MealPlannerComponent(_repoMock.Object, mapper);

            // Act
            var persistedMealPlan = component.CreateMealPlan(mealPlanDomainModel);

            // Assert
            _repoMock.Verify(m => m.AddMealPlan(It.IsAny<Entity.MealPlan>()), Times.Once);
            _repoMock.Verify(m => m.GetUser(It.IsAny<Guid>()), Times.Once);
            Assert.AreEqual(mealPlanEntity.Id, persistedMealPlan.Id);
            Assert.AreEqual(mealPlanDomainModel.Name, persistedMealPlan.Name);
        }

        [TestMethod]
        public void UpdateMealPlan()
        {
            // Arrange
            Guid ownerId = Guid.NewGuid();
            Domain.MealPlan mealPlan = GetMealPlanDomainModelForUpdate(ownerId);
            MealPlannerDomainMapper mapper = new MealPlannerDomainMapper(new MealPlannerDomainMappingConfigurationProvider());

            _repoMock.Setup(m => m.UpdateMealPlan(It.IsAny<Entity.MealPlan>()));
            _repoMock.Setup(m => m.GetMealPlanById(It.IsAny<int>())).Returns(GetMealPlanEntityForUpdate(ownerId));
            IMealPlannerComponent component = new MealPlannerComponent(_repoMock.Object, mapper);

            // Act
            component.UpdateMealPlan(mealPlan);

            // Assert
            _repoMock.Verify(m => m.UpdateMealPlan(It.IsAny<Entity.MealPlan>()), Times.Once);
        }

        [TestMethod]
        public void GetMeals()
        {
            // Arrange
            Guid userId = Guid.NewGuid();

            MealPlannerDomainMapper mapper = new MealPlannerDomainMapper(_mappingConfigProvider);

            _repoMock.Setup(m => m.GetMeals(It.IsAny<Guid>()))
                .Returns(GetMealEntityList(userId));
            IMealPlannerComponent component = new MealPlannerComponent(_repoMock.Object, mapper);
            // Act
            var meals = component.GetMeals(userId);

            // Assert
            _repoMock.Verify(m => m.GetMeals(userId), Times.Once);
            Assert.IsNotNull(meals);
            Assert.AreEqual(1, meals.Count());
        }

        private List<Entity.MealPlan> GetMealPlanList(Guid userId)
        {
            return new List<Entity.MealPlan>()
            {
                GetMealPlanEntity(userId)
            };
        }

        public static Domain.MealPlan GetMealPlanDomainModel(Guid userId)
        {
            var mealPlan = new Domain.MealPlan()
            {
                Id = 0,
                Description = "The Meal Plan of John",
                StartDate = new DateTime(2019, 1, 1),
                EndDate = new DateTime(2019, 1, 30),
                Name = "John's Meal Plan",
                OwnerId = userId,
            };
            
            return mealPlan;
        }

        public static Domain.MealPlan GetMealPlanDomainModelForUpdate(Guid guid)
        {
            var mealPlan = new Domain.MealPlan()
            {
                Id = 45,
                Description = "The Meal Plan of John Updated",
                StartDate = new DateTime(2019, 1, 1),
                EndDate = new DateTime(2019, 1, 30),
                Name = "John's Meal Plan",
                OwnerId = Guid.NewGuid(),
            };

            return mealPlan;
        }

        public static Entity.MealPlan GetMealPlanEntityForUpdate(Guid userId)
        {
            var mealPlan = new Entity.MealPlan()
            {
                Id = 45,
                Description = "The Meal Plan of John",
                StartDate = new DateTime(2019, 1, 1),
                EndDate = new DateTime(2019, 1, 30),
                Name = "John's Meal Plan",
                Owner = GetOwnerEntity(userId),
                OwnerId = 1,
            };
            mealPlan.Meals = GetScheduledMealEntityList(mealPlan);

            return mealPlan;
        }

        public static Entity.MealPlan GetMealPlanEntity(Guid userId)
        {
            var mealPlan = new Entity.MealPlan()
            {
                Id = 1,
                Description = "The Meal Plan of John",
                StartDate = new DateTime(2019, 1, 1),
                EndDate = new DateTime(2019, 1, 30),
                Name = "John's Meal Plan",
                Owner = GetOwnerEntity(userId),
                OwnerId = 1,
            };
            mealPlan.Meals = GetScheduledMealEntityList(mealPlan);

            return mealPlan;
        }

        public static List<Entity.ScheduledMeal> GetScheduledMealEntityList(Entity.MealPlan mealPlan)
        {
            return new List<Entity.ScheduledMeal>()
            {
                GetScheduledMealEntity(mealPlan)
            };
        }

        public static Entity.ScheduledMeal GetScheduledMealEntity(Entity.MealPlan mealPlan)
        {
            Entity.Meal meal = GetMealEntity(mealPlan.Owner.UniqueId);

            return new Entity.ScheduledMeal()
            {
                Id = 1,
                MealId = meal.Id,
                Meal = meal,
                MealPlanId = mealPlan.Id,
                MealPlan = mealPlan,
                ScheduledDateTime = new DateTime(2019, 01, 01),
            };
        }

        public static Entity.Meal GetMealEntity(Guid userId)
        {
            return new Entity.Meal()
            {
                Id = 1,
                Description = "A Meal",
                Name = "Meal",
                Owner = GetOwnerEntity(userId),
                OwnerId = 1,
                MealType = GetMealTypeEntity(),
                MealTypeId = 1
            };
        }

        public static List<Entity.Meal> GetMealEntityList(Guid userId)
        {
            return new List<Entity.Meal>()
            {
                GetMealEntity(userId)
            };
        }

        public static Entity.User GetOwnerEntity(Guid userId)
        {
            return new Entity.User()
            {
                Id = 1,
                Firstname = "John",
                Lastname = "Smith",
                Email = "jsmith@whatever.com",
                UniqueId = userId,
                Username = "jsmith",
            };
        }
        public static Entity.MealType GetMealTypeEntity()
        {
            return new Entity.MealType()
            {
                Id = 1,
                Code = "Breakfast",
                Name = "Bfast",
                IsActive = true,
                Description = "Morning Meal"
            };
        }
    }
}
