﻿// <auto-generated />
using System;
using MealPlanner.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MealPlanner.Database.Migrations.Migrations
{
    [DbContext(typeof(MealPlannerDbContext))]
    [Migration("20190717103751_v2")]
    partial class v2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MealPlanner.Database.Entity.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<int>("MealTypeId");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<int>("OwnerId");

                    b.Property<string>("Version");

                    b.HasKey("Id");

                    b.HasIndex("MealTypeId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Meals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2019, 7, 17, 6, 37, 51, 48, DateTimeKind.Local).AddTicks(9837),
                            MealTypeId = 1,
                            Modified = new DateTime(2019, 7, 17, 6, 37, 51, 48, DateTimeKind.Local).AddTicks(9840),
                            Name = "Eggs and Bacon",
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(1425),
                            MealTypeId = 2,
                            Modified = new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(1433),
                            Name = "Chicken and Hummus Wrap",
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(1456),
                            MealTypeId = 3,
                            Modified = new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(1459),
                            Name = "Tostadas with Veggies",
                            OwnerId = 2
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(1471),
                            MealTypeId = 4,
                            Modified = new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(1474),
                            Name = "Mini pretzels",
                            OwnerId = 2
                        });
                });

            modelBuilder.Entity("MealPlanner.Database.Entity.MealPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<int>("OwnerId");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Version");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("MealPlans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(2610),
                            Description = "Justin's plan for July",
                            EndDate = new DateTime(2019, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Modified = new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(2619),
                            Name = "Justin's Meal Plan",
                            OwnerId = 1,
                            StartDate = new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(3828),
                            Description = "Katie's plan for July",
                            EndDate = new DateTime(2019, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Modified = new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(3836),
                            Name = "Katie's Meal Plan",
                            OwnerId = 2,
                            StartDate = new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MealPlanner.Database.Entity.MealType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Version");

                    b.HasKey("Id");

                    b.ToTable("MealTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "BREAKFAST",
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Morning meal",
                            IsActive = false,
                            Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Breakfast"
                        },
                        new
                        {
                            Id = 2,
                            Code = "LUNCH",
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Afternoon Meal",
                            IsActive = false,
                            Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Lunch"
                        },
                        new
                        {
                            Id = 3,
                            Code = "DINNER",
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Evening Meal",
                            IsActive = false,
                            Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Dinner"
                        },
                        new
                        {
                            Id = 4,
                            Code = "Snack",
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A meal between breakfast, lunch or dinner",
                            IsActive = false,
                            Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Snack"
                        });
                });

            modelBuilder.Entity("MealPlanner.Database.Entity.ScheduledMeal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<int>("MealId");

                    b.Property<int>("MealPlanId");

                    b.Property<DateTime>("Modified");

                    b.Property<DateTime>("ScheduledDateTime");

                    b.Property<string>("Version");

                    b.HasKey("Id");

                    b.HasIndex("MealId");

                    b.HasIndex("MealPlanId");

                    b.ToTable("ScheduledMeals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(5293),
                            MealId = 1,
                            MealPlanId = 1,
                            Modified = new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(5300),
                            ScheduledDateTime = new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(4911)
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(5463),
                            MealId = 2,
                            MealPlanId = 2,
                            Modified = new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(5465),
                            ScheduledDateTime = new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(5457)
                        });
                });

            modelBuilder.Entity("MealPlanner.Database.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254);

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Middlename")
                        .HasMaxLength(50);

                    b.Property<DateTime>("Modified");

                    b.Property<Guid>("UniqueId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(254);

                    b.Property<string>("Version");

                    b.HasKey("Id");

                    b.HasIndex("UniqueId")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2019, 7, 17, 6, 37, 51, 47, DateTimeKind.Local).AddTicks(7146),
                            Email = "jdplank74@live.com",
                            Firstname = "Justin",
                            Lastname = "Plank",
                            Modified = new DateTime(2019, 7, 17, 6, 37, 51, 48, DateTimeKind.Local).AddTicks(9248),
                            UniqueId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Username = "jdplank74"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2019, 7, 17, 6, 37, 51, 48, DateTimeKind.Local).AddTicks(9811),
                            Email = "ktkrus@live.com",
                            Firstname = "Katie",
                            Lastname = "Plank",
                            Modified = new DateTime(2019, 7, 17, 6, 37, 51, 48, DateTimeKind.Local).AddTicks(9821),
                            UniqueId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Username = "ktkrus"
                        });
                });

            modelBuilder.Entity("MealPlanner.Database.Entity.Meal", b =>
                {
                    b.HasOne("MealPlanner.Database.Entity.MealType", "MealType")
                        .WithMany("Meals")
                        .HasForeignKey("MealTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MealPlanner.Database.Entity.User", "Owner")
                        .WithMany("Meals")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MealPlanner.Database.Entity.MealPlan", b =>
                {
                    b.HasOne("MealPlanner.Database.Entity.User", "Owner")
                        .WithMany("MealPlans")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MealPlanner.Database.Entity.ScheduledMeal", b =>
                {
                    b.HasOne("MealPlanner.Database.Entity.Meal", "Meal")
                        .WithMany("ScheduledMeals")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MealPlanner.Database.Entity.MealPlan", "MealPlan")
                        .WithMany("Meals")
                        .HasForeignKey("MealPlanId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}