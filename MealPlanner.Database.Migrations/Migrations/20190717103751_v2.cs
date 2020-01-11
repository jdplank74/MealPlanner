using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MealPlanner.Database.Migrations.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UniqueId",
                schema: "dbo",
                table: "Users",
                nullable: false,
                defaultValueSql: "NEWID()");

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_UniqueId",
                schema: "dbo",
                table: "Users",
                column: "UniqueId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_UniqueId",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UniqueId",
                schema: "dbo",
                table: "Users");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(6498), new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(6506) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(7722), new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(7730) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Meals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(3688), new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(3690) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Meals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(5300), new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(5309) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Meals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(5333), new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(5335) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Meals",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(5349), new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(5351) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ScheduledMeals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified", "ScheduledDateTime" },
                values: new object[] { new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(9215), new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(9223), new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(8837) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ScheduledMeals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Modified", "ScheduledDateTime" },
                values: new object[] { new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(9350), new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(9352), new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(9345) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 7, 13, 17, 17, 27, 270, DateTimeKind.Local).AddTicks(828), new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(3098) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(3660), new DateTime(2019, 7, 13, 17, 17, 27, 271, DateTimeKind.Local).AddTicks(3670) });
        }
    }
}
