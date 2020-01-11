using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MealPlanner.Database.Migrations.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "MealPlans",
                columns: new[] { "Id", "Created", "Description", "EndDate", "Modified", "Name", "OwnerId", "StartDate", "Version" },
                values: new object[] { 3, new DateTime(2019, 8, 6, 5, 22, 6, 920, DateTimeKind.Local).AddTicks(215), "Kids Meal plan for July", new DateTime(2019, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 6, 5, 22, 6, 920, DateTimeKind.Local).AddTicks(217), "Kid's Meal Plan", 2, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Meals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 8, 6, 5, 22, 6, 919, DateTimeKind.Local).AddTicks(6004), new DateTime(2019, 8, 6, 5, 22, 6, 919, DateTimeKind.Local).AddTicks(6006) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Meals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 8, 6, 5, 22, 6, 919, DateTimeKind.Local).AddTicks(7602), new DateTime(2019, 8, 6, 5, 22, 6, 919, DateTimeKind.Local).AddTicks(7611) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Meals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 8, 6, 5, 22, 6, 919, DateTimeKind.Local).AddTicks(7634), new DateTime(2019, 8, 6, 5, 22, 6, 919, DateTimeKind.Local).AddTicks(7636) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Meals",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 8, 6, 5, 22, 6, 919, DateTimeKind.Local).AddTicks(7649), new DateTime(2019, 8, 6, 5, 22, 6, 919, DateTimeKind.Local).AddTicks(7652) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ScheduledMeals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified", "ScheduledDateTime" },
                values: new object[] { new DateTime(2019, 8, 6, 5, 22, 6, 920, DateTimeKind.Local).AddTicks(1788), new DateTime(2019, 8, 6, 5, 22, 6, 920, DateTimeKind.Local).AddTicks(1795), new DateTime(2019, 8, 6, 5, 22, 6, 920, DateTimeKind.Local).AddTicks(1370) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ScheduledMeals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Modified", "ScheduledDateTime" },
                values: new object[] { new DateTime(2019, 8, 6, 5, 22, 6, 920, DateTimeKind.Local).AddTicks(2023), new DateTime(2019, 8, 6, 5, 22, 6, 920, DateTimeKind.Local).AddTicks(2025), new DateTime(2019, 8, 6, 5, 22, 6, 920, DateTimeKind.Local).AddTicks(2018) });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 8, 5, 6, 24, 21, 166, DateTimeKind.Local).AddTicks(3917), new DateTime(2019, 8, 5, 6, 24, 21, 166, DateTimeKind.Local).AddTicks(3926) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 8, 5, 6, 24, 21, 166, DateTimeKind.Local).AddTicks(5309), new DateTime(2019, 8, 5, 6, 24, 21, 166, DateTimeKind.Local).AddTicks(5317) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Meals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 8, 5, 6, 24, 21, 166, DateTimeKind.Local).AddTicks(1197), new DateTime(2019, 8, 5, 6, 24, 21, 166, DateTimeKind.Local).AddTicks(1199) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Meals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 8, 5, 6, 24, 21, 166, DateTimeKind.Local).AddTicks(2732), new DateTime(2019, 8, 5, 6, 24, 21, 166, DateTimeKind.Local).AddTicks(2741) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Meals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 8, 5, 6, 24, 21, 166, DateTimeKind.Local).AddTicks(2772), new DateTime(2019, 8, 5, 6, 24, 21, 166, DateTimeKind.Local).AddTicks(2774) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Meals",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 8, 5, 6, 24, 21, 166, DateTimeKind.Local).AddTicks(2788), new DateTime(2019, 8, 5, 6, 24, 21, 166, DateTimeKind.Local).AddTicks(2790) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ScheduledMeals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified", "ScheduledDateTime" },
                values: new object[] { new DateTime(2019, 8, 5, 6, 24, 21, 166, DateTimeKind.Local).AddTicks(6782), new DateTime(2019, 8, 5, 6, 24, 21, 166, DateTimeKind.Local).AddTicks(6790), new DateTime(2019, 8, 5, 6, 24, 21, 166, DateTimeKind.Local).AddTicks(6398) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ScheduledMeals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Modified", "ScheduledDateTime" },
                values: new object[] { new DateTime(2019, 8, 5, 6, 24, 21, 166, DateTimeKind.Local).AddTicks(6926), new DateTime(2019, 8, 5, 6, 24, 21, 166, DateTimeKind.Local).AddTicks(6928), new DateTime(2019, 8, 5, 6, 24, 21, 166, DateTimeKind.Local).AddTicks(6921) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 8, 5, 6, 24, 21, 166, DateTimeKind.Local).AddTicks(186), new DateTime(2019, 8, 5, 6, 24, 21, 166, DateTimeKind.Local).AddTicks(630) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 8, 5, 6, 24, 21, 166, DateTimeKind.Local).AddTicks(1170), new DateTime(2019, 8, 5, 6, 24, 21, 166, DateTimeKind.Local).AddTicks(1180) });
        }
    }
}
