using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MealPlanner.Database.Migrations.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "MealTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Code = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 80, nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    Firstname = table.Column<string>(maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(maxLength: 50, nullable: false),
                    Middlename = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 254, nullable: false),
                    Username = table.Column<string>(maxLength: 254, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealPlans",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealPlans_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    OwnerId = table.Column<int>(nullable: false),
                    MealTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meals_MealTypes_MealTypeId",
                        column: x => x.MealTypeId,
                        principalSchema: "dbo",
                        principalTable: "MealTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meals_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledMeals",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    ScheduledDateTime = table.Column<DateTime>(nullable: false),
                    MealId = table.Column<int>(nullable: false),
                    MealPlanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledMeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledMeals_Meals_MealId",
                        column: x => x.MealId,
                        principalSchema: "dbo",
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ScheduledMeals_MealPlans_MealPlanId",
                        column: x => x.MealPlanId,
                        principalSchema: "dbo",
                        principalTable: "MealPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "MealTypes",
                columns: new[] { "Id", "Code", "Created", "Description", "IsActive", "Modified", "Name", "Version" },
                values: new object[,]
                {
                    { 1, "BREAKFAST", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Morning meal", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Breakfast", null },
                    { 2, "LUNCH", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Afternoon Meal", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lunch", null },
                    { 3, "DINNER", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evening Meal", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dinner", null },
                    { 4, "Snack", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A meal between breakfast, lunch or dinner", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Snack", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "Created", "Email", "Firstname", "Lastname", "Middlename", "Modified", "Username", "Version" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 7, 13, 17, 17, 27, 270, DateTimeKind.Local).AddTicks(828), "jdplank74@live.com", "Justin", "Plank", null, new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(3098), "jdplank74", null },
                    { 2, new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(3660), "ktkrus@live.com", "Katie", "Plank", null, new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(3670), "ktkrus", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "MealPlans",
                columns: new[] { "Id", "Created", "Description", "EndDate", "Modified", "Name", "OwnerId", "StartDate", "Version" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(6498), "Justin's plan for July", new DateTime(2019, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(6506), "Justin's Meal Plan", 1, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(7722), "Katie's plan for July", new DateTime(2019, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(7730), "Katie's Meal Plan", 2, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Meals",
                columns: new[] { "Id", "Created", "Description", "MealTypeId", "Modified", "Name", "OwnerId", "Version" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(3688), null, 1, new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(3690), "Eggs and Bacon", 1, null },
                    { 2, new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(5300), null, 2, new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(5309), "Chicken and Hummus Wrap", 1, null },
                    { 3, new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(5333), null, 3, new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(5335), "Tostadas with Veggies", 2, null },
                    { 4, new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(5349), null, 4, new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(5351), "Mini pretzels", 2, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ScheduledMeals",
                columns: new[] { "Id", "Created", "MealId", "MealPlanId", "Modified", "ScheduledDateTime", "Version" },
                values: new object[] { 1, new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(9215), 1, 1, new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(9223), new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(8837), null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ScheduledMeals",
                columns: new[] { "Id", "Created", "MealId", "MealPlanId", "Modified", "ScheduledDateTime", "Version" },
                values: new object[] { 2, new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(9350), 2, 2, new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(9352), new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(9345), null });

            migrationBuilder.CreateIndex(
                name: "IX_MealPlans_OwnerId",
                schema: "dbo",
                table: "MealPlans",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MealTypeId",
                schema: "dbo",
                table: "Meals",
                column: "MealTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_OwnerId",
                schema: "dbo",
                table: "Meals",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledMeals_MealId",
                schema: "dbo",
                table: "ScheduledMeals",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledMeals_MealPlanId",
                schema: "dbo",
                table: "ScheduledMeals",
                column: "MealPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduledMeals",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Meals",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MealPlans",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MealTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");
        }
    }
}
