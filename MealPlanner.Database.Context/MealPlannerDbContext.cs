using MealPlanner.Database.Entity;
using MealPlanner.Utilities.Date;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlanner.Database.Context
{
    [ExcludeFromCodeCoverage]
    public class MealPlannerDbContext : DbContext, IMealPlannerDbContext
    {
        private DateTimeAdapter _dtAdapter = new DateTimeAdapter();

        public MealPlannerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }
        public DbSet<MealType> MealTypes { get; set; }
        public DbSet<ScheduledMeal> ScheduledMeals { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(DbConstants.SchemaName);
            base.OnModelCreating(builder);

            // Add Index and Unique constraint on the UniqueId of the User
            builder.Entity<User>()
                .HasIndex(u => u.UniqueId)
                .IsUnique();

            builder.Entity<User>()
                .Property(u => u.UniqueId)
                .HasDefaultValueSql("NEWID()");

            // Configure many-to-many relationship  between Meals and Users
            builder.Entity<Meal>()
                .HasOne<User>(m => m.Owner)
                .WithMany(u => u.Meals)
                .HasForeignKey(m => m.OwnerId);

            builder.Entity<Meal>()
                .HasOne<MealType>(m => m.MealType)
                .WithMany(mt => mt.Meals)
                .HasForeignKey(m => m.MealTypeId);

            // Configure relation ships for MealPlan
            builder.Entity<MealPlan>()
                .HasOne<User>(mp => mp.Owner)
                .WithMany(u => u.MealPlans)
                .HasForeignKey(mp => mp.OwnerId);
            builder.Entity<MealPlan>()
                .HasMany(mp => mp.Meals)
                .WithOne(sm => sm.MealPlan);
                

            // Configure relationships for ScheduledMeals
            builder.Entity<ScheduledMeal>()
                .HasOne<MealPlan>(sm => sm.MealPlan)
                .WithMany(mp => mp.Meals)
                .HasForeignKey(sm => sm.MealPlanId);

            builder.Entity<ScheduledMeal>()
                .HasOne<Meal>(sm => sm.Meal)
                .WithMany(m => m.ScheduledMeals)
                .HasForeignKey(sm => sm.MealId);

            // Add MealType
            builder.Entity<MealType>()
                .HasData(new MealType { Id = 1, Name = "Breakfast", Code = "BREAKFAST", Description = "Morning meal" });
            builder.Entity<MealType>()
                .HasData(new MealType { Id = 2, Name = "Lunch", Code = "LUNCH", Description = "Afternoon Meal" });
            builder.Entity<MealType>()
                .HasData(new MealType { Id = 3, Name = "Dinner", Code = "DINNER", Description = "Evening Meal" });
            builder.Entity<MealType>()
                .HasData(new MealType { Id = 4, Name = "Snack", Code = "Snack", Description = "A meal between breakfast, lunch or dinner" });

            // Add Users
            builder.Entity<User>()
                .HasData(new User { Id = 1, Username = "jdplank74", Firstname = "Justin", Lastname = "Plank", Email = "jdplank74@live.com", Created = _dtAdapter.Now(), Modified = _dtAdapter.Now() });
            builder.Entity<User>()
                .HasData(new User { Id = 2, Username = "ktkrus", Firstname = "Katie", Lastname = "Plank", Email = "ktkrus@live.com", Created = _dtAdapter.Now(), Modified = _dtAdapter.Now() });


            // Add Meals 
            builder.Entity<Meal>()
                .HasData(new { Id = 10, MealTypeId = 1, Name = "Eggs and Bacon", Created = _dtAdapter.Now(), Modified = _dtAdapter.Now(), OwnerId = 1 });
            builder.Entity<Meal>()
                .HasData(new { Id = 20, MealTypeId = 2, Name = "Chicken and Hummus Wrap", Created = _dtAdapter.Now(), Modified = _dtAdapter.Now(), OwnerId = 1 });
            builder.Entity<Meal>()
                .HasData(new { Id = 30, MealTypeId = 3, Name = "Tostadas with Veggies", Created = _dtAdapter.Now(), Modified = _dtAdapter.Now(), OwnerId = 2 });
            builder.Entity<Meal>()
                .HasData(new { Id = 40, MealTypeId = 4, Name = "Mini pretzels", Created = _dtAdapter.Now(), Modified = _dtAdapter.Now(), OwnerId = 2 });


            // Add MealPlans
            DateTime startDate = new DateTime(2019, 7, 1);
            DateTime endDate = new DateTime(2019, 7, 31);
            DateTime createDate = new DateTime(2019, 6, 15);
            builder.Entity<MealPlan>()
                .HasData(
                new MealPlan()
                {
                    Id = 1,
                    Name = "Justin's Meal Plan",
                    Description = "Justin's plan for July",
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    StartDate = startDate,
                    EndDate = endDate,
                    OwnerId = 1,
                });

            builder.Entity<MealPlan>()
                .HasData(
                new MealPlan()
                {
                    Id = 2,
                    Name = "Katie's Meal Plan",
                    Description = "Katie's plan for July",
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    StartDate = startDate,
                    EndDate = endDate,
                    OwnerId = 2,
                });
            builder.Entity<MealPlan>()
                .HasData(
                new MealPlan()
                {
                    Id = 3,
                    Name = "Kid's Meal Plan",
                    Description = "Kids Meal plan for July",
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    StartDate = startDate,
                    EndDate = endDate,
                    OwnerId = 2,
                });
            // Add Scheduled User Meals
            builder.Entity<ScheduledMeal>()
                .HasData(new ScheduledMeal{ Id = 100, MealId = 10, MealPlanId = 1, ScheduledDateTime = _dtAdapter.Now(), Created = _dtAdapter.Now(), Modified = _dtAdapter.Now() });
            builder.Entity<ScheduledMeal>()
                .HasData(new ScheduledMeal{ Id = 200, MealId = 20, MealPlanId = 2, ScheduledDateTime = _dtAdapter.Now(), Created = _dtAdapter.Now(), Modified = _dtAdapter.Now() });

        }

        public override int SaveChanges()
        {
            AddAuditInfo();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddAuditInfo();
            return await base.SaveChangesAsync();
        }

        public void AddAuditInfo()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is EntityBase && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                DateTime now = _dtAdapter.Now();

                if (entry.State == EntityState.Added)
                {
                    ((EntityBase)entry.Entity).Created = now;
                }
                ((EntityBase)entry.Entity).Modified = now;
            }
        }

    }
}

