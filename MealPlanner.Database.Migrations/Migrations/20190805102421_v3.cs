using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MealPlanner.Database.Migrations.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(2610), new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(2619) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(3828), new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(3836) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Meals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 7, 17, 6, 37, 51, 48, DateTimeKind.Local).AddTicks(9837), new DateTime(2019, 7, 17, 6, 37, 51, 48, DateTimeKind.Local).AddTicks(9840) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Meals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(1425), new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(1433) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Meals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(1456), new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(1459) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Meals",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(1471), new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(1474) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ScheduledMeals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified", "ScheduledDateTime" },
                values: new object[] { new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(5293), new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(5300), new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(4911) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ScheduledMeals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Modified", "ScheduledDateTime" },
                values: new object[] { new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(5463), new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(5465), new DateTime(2019, 7, 17, 6, 37, 51, 49, DateTimeKind.Local).AddTicks(5457) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 7, 17, 6, 37, 51, 47, DateTimeKind.Local).AddTicks(7146), new DateTime(2019, 7, 17, 6, 37, 51, 48, DateTimeKind.Local).AddTicks(9248) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 7, 17, 6, 37, 51, 48, DateTimeKind.Local).AddTicks(9811), new DateTime(2019, 7, 17, 6, 37, 51, 48, DateTimeKind.Local).AddTicks(9821) });
        }
    }
}
