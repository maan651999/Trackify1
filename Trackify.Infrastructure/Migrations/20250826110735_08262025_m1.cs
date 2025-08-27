using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Trackify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _08262025_m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "DietId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "DietId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "DietId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "DietId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Progresses",
                keyColumn: "ProgressId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 1,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 2,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 3,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 4,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 5,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 6,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 7,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 8,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 9,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 10,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 11,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 12,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 13,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 14,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 15,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 16,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 17,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 18,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 19,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 20,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 21,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 22,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 23,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 24,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 25,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 26,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 27,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 28,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 29,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 30,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 31,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 32,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 33,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 34,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 35,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 36,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 37,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 38,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 39,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 40,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 41,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 42,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 43,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 44,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 45,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 46,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 47,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 48,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 49,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 50,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 51,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 52,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 53,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 54,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 55,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 56,
                column: "UserId",
                value: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Expenses");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Age", "CreatedDate", "Email", "FullName", "Gender", "Goal", "Height", "IsActive", "LastLoginDate", "LastLoginIP", "PasswordHash", "Phone", "PhotoUrl", "Weight" },
                values: new object[] { 1, 26, new DateTime(2025, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Mohit", "Male", "Recomposition", 172m, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "/images/default.png", 75m });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 1,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 2,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 3,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 4,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 5,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 6,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 7,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 8,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 9,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 10,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 11,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 12,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 13,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 14,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 15,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 16,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 17,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 18,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 19,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 20,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 21,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 22,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 23,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 24,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 25,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 26,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 27,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 28,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 29,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 30,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 31,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 32,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 33,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 34,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 35,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 36,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 37,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 38,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 39,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 40,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 41,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 42,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 43,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 44,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 45,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 46,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 47,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 48,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 49,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 50,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 51,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 52,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 53,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 54,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 55,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 56,
                column: "UserId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "DietId", "Calories", "Carbs", "Fats", "FoodItem", "MealTime", "MealType", "Protein", "UserId" },
                values: new object[,]
                {
                    { 1, 250m, 35m, 8m, "Banana + 10 Almonds", new DateTime(2025, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pre-Workout", 6m, 1 },
                    { 2, 230m, 8m, 3m, "Veg Whey (1 scoop) + Curd 100g", new DateTime(2025, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post-Workout", 34m, 1 },
                    { 3, 750m, 70m, 22m, "Paneer 150g + Dal + 2 Phulka", new DateTime(2025, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lunch", 45m, 1 },
                    { 4, 340m, 20m, 12m, "Tofu 150g + Veg Stir Fry", new DateTime(2025, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dinner", 30m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Progresses",
                columns: new[] { "ProgressId", "Arms", "BodyFat", "Chest", "Date", "Legs", "PhotoPath", "UserId", "Waist", "Weight" },
                values: new object[] { 1, 0m, 0m, 0m, new DateTime(2025, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, "", 1, 88m, 75m });
        }
    }
}
