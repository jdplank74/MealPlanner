using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MealPlanner.Database.Migrations.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Meals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Meals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ScheduledMeals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ScheduledMeals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Meals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Meals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 8, 8, 6, 18, 10, 400, DateTimeKind.Local).AddTicks(7018), new DateTime(2019, 8, 8, 6, 18, 10, 400, DateTimeKind.Local).AddTicks(7026) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 8, 8, 6, 18, 10, 400, DateTimeKind.Local).AddTicks(8220), new DateTime(2019, 8, 8, 6, 18, 10, 400, DateTimeKind.Local).AddTicks(8228) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 8, 8, 6, 18, 10, 400, DateTimeKind.Local).AddTicks(8246), new DateTime(2019, 8, 8, 6, 18, 10, 400, DateTimeKind.Local).AddTicks(8248) });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Meals",
                columns: new[] { "Id", "Created", "Description", "MealTypeId", "Modified", "Name", "OwnerId", "Version" },
                values: new object[,]
                {
                    { 10, new DateTime(2019, 8, 8, 6, 18, 10, 400, DateTimeKind.Local).AddTicks(4302), null, 1, new DateTime(2019, 8, 8, 6, 18, 10, 400, DateTimeKind.Local).AddTicks(4304), "Eggs and Bacon", 1, null },
                    { 20, new DateTime(2019, 8, 8, 6, 18, 10, 400, DateTimeKind.Local).AddTicks(5868), null, 2, new DateTime(2019, 8, 8, 6, 18, 10, 400, DateTimeKind.Local).AddTicks(5876), "Chicken and Hummus Wrap", 1, null },
                    { 30, new DateTime(2019, 8, 8, 6, 18, 10, 400, DateTimeKind.Local).AddTicks(5899), null, 3, new DateTime(2019, 8, 8, 6, 18, 10, 400, DateTimeKind.Local).AddTicks(5901), "Tostadas with Veggies", 2, null },
                    { 40, new DateTime(2019, 8, 8, 6, 18, 10, 400, DateTimeKind.Local).AddTicks(5914), null, 4, new DateTime(2019, 8, 8, 6, 18, 10, 400, DateTimeKind.Local).AddTicks(5916), "Mini pretzels", 2, null }
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 8, 8, 6, 18, 10, 400, DateTimeKind.Local).AddTicks(3287), new DateTime(2019, 8, 8, 6, 18, 10, 400, DateTimeKind.Local).AddTicks(3738) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 8, 8, 6, 18, 10, 400, DateTimeKind.Local).AddTicks(4276), new DateTime(2019, 8, 8, 6, 18, 10, 400, DateTimeKind.Local).AddTicks(4285) });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ScheduledMeals",
                columns: new[] { "Id", "Created", "MealId", "MealPlanId", "Modified", "ScheduledDateTime", "Version" },
                values: new object[] { 100, new DateTime(2019, 8, 8, 6, 18, 10, 400, DateTimeKind.Local).AddTicks(9674), 10, 1, new DateTime(2019, 8, 8, 6, 18, 10, 400, DateTimeKind.Local).AddTicks(9682), new DateTime(2019, 8, 8, 6, 18, 10, 400, DateTimeKind.Local).AddTicks(9299), null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ScheduledMeals",
                columns: new[] { "Id", "Created", "MealId", "MealPlanId", "Modified", "ScheduledDateTime", "Version" },
                values: new object[] { 200, new DateTime(2019, 8, 8, 6, 18, 10, 400, DateTimeKind.Local).AddTicks(9819), 20, 2, new DateTime(2019, 8, 8, 6, 18, 10, 400, DateTimeKind.Local).AddTicks(9821), new DateTime(2019, 8, 8, 6, 18, 10, 400, DateTimeKind.Local).AddTicks(9815), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Meals",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Meals",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ScheduledMeals",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ScheduledMeals",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Meals",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Meals",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 8, 6, 5, 22, 6, 919, DateTimeKind.Local).AddTicks(8851), new DateTime(2019, 8, 6, 5, 22, 6, 919, DateTimeKind.Local).AddTicks(8859) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 8, 6, 5, 22, 6, 920, DateTimeKind.Local).AddTicks(188), new DateTime(2019, 8, 6, 5, 22, 6, 920, DateTimeKind.Local).AddTicks(196) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 8, 6, 5, 22, 6, 920, DateTimeKind.Local).AddTicks(215), new DateTime(2019, 8, 6, 5, 22, 6, 920, DateTimeKind.Local).AddTicks(217) });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Meals",
                columns: new[] { "Id", "Created", "Description", "MealTypeId", "Modified", "Name", "OwnerId", "Version" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 8, 6, 5, 22, 6, 919, DateTimeKind.Local).AddTicks(6004), null, 1, new DateTime(2019, 8, 6, 5, 22, 6, 919, DateTimeKind.Local).AddTicks(6006), "Eggs and Bacon", 1, null },
                    { 2, new DateTime(2019, 8, 6, 5, 22, 6, 919, DateTimeKind.Local).AddTicks(7602), null, 2, new DateTime(2019, 8, 6, 5, 22, 6, 919, DateTimeKind.Local).AddTicks(7611), "Chicken and Hummus Wrap", 1, null },
                    { 3, new DateTime(2019, 8, 6, 5, 22, 6, 919, DateTimeKind.Local).AddTicks(7634), null, 3, new DateTime(2019, 8, 6, 5, 22, 6, 919, DateTimeKind.Local).AddTicks(7636), "Tostadas with Veggies", 2, null },
                    { 4, new DateTime(2019, 8, 6, 5, 22, 6, 919, DateTimeKind.Local).AddTicks(7649), null, 4, new DateTime(2019, 8, 6, 5, 22, 6, 919, DateTimeKind.Local).AddTicks(7652), "Mini pretzels", 2, null }
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 8, 6, 5, 22, 6, 919, DateTimeKind.Local).AddTicks(4942), new DateTime(2019, 8, 6, 5, 22, 6, 919, DateTimeKind.Local).AddTicks(5409) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 8, 6, 5, 22, 6, 919, DateTimeKind.Local).AddTicks(5978), new DateTime(2019, 8, 6, 5, 22, 6, 919, DateTimeKind.Local).AddTicks(5988) });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ScheduledMeals",
                columns: new[] { "Id", "Created", "MealId", "MealPlanId", "Modified", "ScheduledDateTime", "Version" },
                values: new object[] { 1, new DateTime(2019, 8, 6, 5, 22, 6, 920, DateTimeKind.Local).AddTicks(1788), 1, 1, new DateTime(2019, 8, 6, 5, 22, 6, 920, DateTimeKind.Local).AddTicks(1795), new DateTime(2019, 8, 6, 5, 22, 6, 920, DateTimeKind.Local).AddTicks(1370), null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ScheduledMeals",
                columns: new[] { "Id", "Created", "MealId", "MealPlanId", "Modified", "ScheduledDateTime", "Version" },
                values: new object[] { 2, new DateTime(2019, 8, 6, 5, 22, 6, 920, DateTimeKind.Local).AddTicks(2023), 2, 2, new DateTime(2019, 8, 6, 5, 22, 6, 920, DateTimeKind.Local).AddTicks(2025), new DateTime(2019, 8, 6, 5, 22, 6, 920, DateTimeKind.Local).AddTicks(2018), null });
        }
    }
}
