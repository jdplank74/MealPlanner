using MealPlanner.Database.Context;
using MealPlanner.Database.Entity;
using MealPlanner.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MealPlanner.DataAccess.Repository.Tests
{
    
    [TestClass]
    public class MealPlannerRepositoryTest
    {
        private Mock<IMealPlannerDbContext> _dbContextMock;

        [TestInitialize]
        public void Initialize()
        {
            _dbContextMock = new Mock<IMealPlannerDbContext>();
        }

        [TestMethod]
        public void GetMealPlansByUser()
        {
            // Arrange
            List<MealPlan> mealPlanList = GetMealPlansForSetMock();
            var userId = mealPlanList[0].Owner.UniqueId;
            var mockSet = CreateDbSetMock<MealPlan>(mealPlanList.AsQueryable<MealPlan>());
            _dbContextMock.Setup(db => db.MealPlans).Returns(mockSet.Object);

            IMealPlannerRepository repository = new MealPlannerRepository(_dbContextMock.Object);

            // Act
            var mealPlans = repository.GetMealPlansByUser(userId);

            // Assert
            _dbContextMock.Verify(db => db.MealPlans, Times.Once);
            Assert.AreEqual(1, mealPlans.Count());
            Assert.IsTrue(mealPlans.Where(mp => mp.Name.Equals("John's Meal Plan")).Any());
        }

        [TestMethod]
        public void GetMealPlanById()
        {
            // Arrange
            int id = 2;
            List<MealPlan> mealPlanList = GetMealPlansForSetMock();
            var mockSet = CreateDbSetMock<MealPlan>(mealPlanList.AsQueryable<MealPlan>());

            _dbContextMock.Setup(m => m.MealPlans).Returns(mockSet.Object);

            IMealPlannerRepository repository = new MealPlannerRepository(_dbContextMock.Object);

            // Act 
            var mealPlan = repository.GetMealPlanById(id);

            // Assert
            _dbContextMock.Verify(m => m.MealPlans, Times.Once);
            Assert.IsNotNull(mealPlan);
            Assert.AreEqual(id, mealPlan.Id);
        }

        [TestMethod]
        public void GetMealPlansByUserNoMatches()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            var mockSet = CreateDbSetMock<MealPlan>(GetMealPlansForSetMock().AsQueryable<MealPlan>());
            _dbContextMock.Setup(db => db.MealPlans).Returns(mockSet.Object);

            IMealPlannerRepository repository = new MealPlannerRepository(_dbContextMock.Object);

            // Act
            var mealPlans = repository.GetMealPlansByUser(userId);

            // Assert
            _dbContextMock.Verify(db => db.MealPlans, Times.Once);
            Assert.AreEqual(0, mealPlans.Count());
        }

        [TestMethod]
        public void GetScheduledMeals()
        {
            // Arrange
            int mealPlanId = 1;
            var mockSet = CreateDbSetMock<ScheduledMeal>(GetScheduledMealsList().AsQueryable<ScheduledMeal>());
            _dbContextMock.Setup(db => db.ScheduledMeals).Returns(mockSet.Object);

            IMealPlannerRepository repository = new MealPlannerRepository(_dbContextMock.Object);

            // Act
            var scheduledMeals = repository.GetScheduledMeals(mealPlanId);

            // Assert
            _dbContextMock.Verify(db => db.ScheduledMeals, Times.Once);
            Assert.AreEqual(2, scheduledMeals.Count());
            Assert.IsTrue(scheduledMeals.Where(sm => sm.Meal.Name.Equals("Ham and Cheese")).Any());
            Assert.IsTrue(scheduledMeals.Where(sm => sm.Meal.MealType.Code.Equals("BREAKFAST")).Any());
        }

        [TestMethod]
        public void GetScheduledMealsMatches()
        {
            // Arrange
            int mealPlanId = 3;
            var mockSet = CreateDbSetMock<ScheduledMeal>(GetScheduledMealsList().AsQueryable<ScheduledMeal>());
            _dbContextMock.Setup(db => db.ScheduledMeals).Returns(mockSet.Object);

            IMealPlannerRepository repository = new MealPlannerRepository(_dbContextMock.Object);

            // Act
            var scheduledMeals = repository.GetScheduledMeals(mealPlanId);

            // Assert
            _dbContextMock.Verify(db => db.ScheduledMeals, Times.Once);
            Assert.AreEqual(0, scheduledMeals.Count());
        }

        [TestMethod]
        public void AddMealPlan()
        {
            // Arrange
            var mealPlan = GetMealPlanEntity();
            var mockSet = CreateDbSetMock<MealPlan>(GetMealPlansForSetMock().AsQueryable<MealPlan>());
            _dbContextMock.Setup(db => db.MealPlans).Returns(mockSet.Object);

            IMealPlannerRepository repository = new MealPlannerRepository(_dbContextMock.Object);

            // Act
            var mealPlanOut = repository.AddMealPlan(mealPlan);

            // Assert
            _dbContextMock.Verify(db => db.MealPlans, Times.Once);
            Assert.AreEqual(mealPlan.Name, mealPlanOut.Name);
        }

        [TestMethod]
        public void UpdateMealPlan()
        {
            // Arrange
            var mealPlan = GetMealPlanEntityForUpdate();
            var mockSet = CreateDbSetMock<MealPlan>(GetMealPlansForSetMock().AsQueryable<MealPlan>());

            _dbContextMock.Setup(m => m.MealPlans).Returns(mockSet.Object);
            _dbContextMock.Setup(m => m.SaveChanges());
            IMealPlannerRepository repository = new MealPlannerRepository(_dbContextMock.Object);
            
            // Act 
            repository.UpdateMealPlan(mealPlan);

            // Assert
            _dbContextMock.Verify(m => m.MealPlans,Times.AtLeastOnce);
            _dbContextMock.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void GetUser()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            User user = GetOwner1(userId);
            var mockSet = CreateDbSetMock<User>(new List<User>() { GetOwner1(userId) }.AsQueryable<User>());
            _dbContextMock.Setup(m => m.Users).Returns(mockSet.Object);

            IMealPlannerRepository repository = new MealPlannerRepository(_dbContextMock.Object);

            // Act
            var userReturned = repository.GetUser(userId);

            // Assert
            _dbContextMock.Verify(m => m.Users, Times.Once);
            Assert.AreEqual(user.Id, userReturned.Id);
        }

        [TestMethod]
        public void GetMeals()
        {
            // Arrange
            Guid userId = Guid.NewGuid();

            var mockSet = CreateDbSetMock<Meal>(GetMeals(userId).AsQueryable<Meal>());
            _dbContextMock.Setup(m => m.Meals).Returns(mockSet.Object);

            IMealPlannerRepository repository = new MealPlannerRepository(_dbContextMock.Object);

            // Act
            var mealsReturned = repository.GetMeals(userId);

            // Assert
            _dbContextMock.Verify(m => m.Meals, Times.Once);
            Assert.AreEqual(1, mealsReturned.Count());
        }

        private List<MealPlan> GetMealPlansForSetMock()
        {
            var userId1 = Guid.NewGuid();
            var owner1 = GetOwner1(userId1);

            var userId2 = Guid.NewGuid();
            var owner2 = GetOwner1(userId2);

            return new List<MealPlan>()
            {
                new MealPlan()
                {
                    Id = 1,
                    Description = "John's plan for July",
                    Name = "John's Meal Plan",
                    OwnerId = owner1.Id,
                    Owner = owner1
                },
                new MealPlan()
                {
                    Id = 2,
                    Description = "Maggie's plan for July",
                    Name = "Maggie's Meal Plan",
                    OwnerId = owner2.Id,
                    Owner = owner2
                },
            };
        }

        private List<ScheduledMeal> GetScheduledMealsList()
        {
            Guid userId = Guid.NewGuid();
            User owner = GetOwner1(userId);
            MealPlan mealPlan = new MealPlan()
            {
                Id = 1,
                Name = "John's meal plan",
                Description = "John's meal plan",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                StartDate = DateTime.Now.Subtract(new TimeSpan(7, 0, 0, 0)),
                EndDate = DateTime.Now,
                Owner = owner,
                OwnerId = 1
            };

            var scheduledMeals = new List<ScheduledMeal>()
            {
                new ScheduledMeal()
                {
                    Id = 1,
                    Meal = new Meal()
                    {
                        Id = 1,
                        Name = "Cap n Crunch",
                        Description = "A nostalgic favorite",
                        MealTypeId = 1,
                        MealType = new MealType()
                        {
                            Id = 1,
                            Name = "Breakfast",
                            Code = "BREAKFAST",
                            Description = "Morning meal",
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                            IsActive = true
                        }
                    },
                    MealPlanId = 1,
                    MealPlan = mealPlan
                },
                new ScheduledMeal()
                {
                    Id = 2,
                    MealId = 2,
                    Meal = new Meal()
                    {
                        Id = 2,
                        Name = "Ham and Cheese",
                        Description = "Yummy!",
                        MealTypeId = 1,
                        MealType = new MealType()
                        {
                            Id = 2,
                            Name = "Lunch",
                            Code = "LUNCH",
                            Description = "Meal during the day",
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                            IsActive = true
                        }
                    },
                    MealPlanId = 1,
                    MealPlan = mealPlan,
                    
                }
            };
            return scheduledMeals;
        }

        private MealPlan GetMealPlanEntity()
        {
            var userId = Guid.NewGuid();
            var owner = GetOwner1(userId);
            return new MealPlan()
            {
                Id = 0,
                Name = "John Smith's Meal Plan",
                Description = "The Meal Plan of John Smith",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Meals = new List<ScheduledMeal>(),
                StartDate = new DateTime(2019, 8, 1),
                EndDate = new DateTime(2019, 8, 31),
                Owner = owner,
                OwnerId = owner.Id
            };
        }

        private MealPlan GetMealPlanEntityForUpdate()
        {
            var userId = Guid.NewGuid();
            var owner = GetOwner2(userId);
            return new MealPlan()
            {
                Id = 2,
                Description = "Maggie's plan for July",
                Name = "Maggie's Meal Plan",
                OwnerId = owner.Id,
                Owner = owner
            };
        }

        private User GetOwner1(Guid userId)
        {
            return new User()
            {
                Id = 1,
                Firstname = "John",
                Lastname = "Smith",
                UniqueId = userId,
                Email = "john@whatever.com",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Username = "jsmith",
                MealPlans = new List<MealPlan>(),
                Meals = new List<Meal>()
            };
        }

        private User GetOwner2(Guid userId)
        {
            return new User()
            {
                Id = 2,
                Firstname = "Maggie",
                Lastname = "Smith",
                UniqueId = userId,
                Email = "maggie@whatever.com",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Username = "msmith",
                MealPlans = new List<MealPlan>(),
                Meals = new List<Meal>()
            };
        }

        private List<Meal> GetMeals(Guid userId)
        {
            User owner = GetOwner1(userId);
            return new List<Meal>()
            {
                new Meal()
                {
                    Id = 32,
                    Name = "P B and J",
                    Description = "Peanut Butter and Jelly",
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    MealType = new MealType()
                    {
                        Id = 2,
                        Name = "Lunch",
                        IsActive = true
                    },
                    MealTypeId = 2,
                    Owner = owner,
                    OwnerId = owner.Id,
                }
            };
        }

        private Mock<DbSet<T>> CreateDbSetMock<T>(IQueryable<T> data) where T : class
        {
            var mockDbSet = new Mock<DbSet<T>>();

            mockDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return mockDbSet;
        }
    }
}
