using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Trackify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _14082025_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DietPlans");

            migrationBuilder.AddColumn<DateTime>(
                name: "Focus",
                table: "Workouts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "WeekNumber",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutDayId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sets = table.Column<int>(type: "int", nullable: false),
                    Reps = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Completed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Workouts_WorkoutDayId",
                        column: x => x.WorkoutDayId,
                        principalTable: "Workouts",
                        principalColumn: "WorkoutId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    DietId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MealTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MealType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodItem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Protein = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Carbs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Calories = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fats = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.DietId);
                    table.ForeignKey(
                        name: "FK_Meals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Age", "CreatedDate", "Email", "FullName", "Gender", "Goal", "Height", "IsActive", "LastLoginDate", "LastLoginIP", "PasswordHash", "Phone", "PhotoUrl", "Weight" },
                values: new object[] { 1, 26, new DateTime(2025, 8, 14, 8, 54, 17, 967, DateTimeKind.Utc).AddTicks(2701), "", "Mohit", "Male", "Recomposition", 172m, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "/images/default.png", 75m });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "DietId", "Calories", "Carbs", "Fats", "FoodItem", "MealTime", "MealType", "Protein", "UserId" },
                values: new object[,]
                {
                    { 1, 250m, 35m, 8m, "Banana + 10 Almonds", new DateTime(2025, 8, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Pre-Workout", 6m, 1 },
                    { 2, 230m, 8m, 3m, "Veg Whey (1 scoop) + Curd 100g", new DateTime(2025, 8, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Post-Workout", 34m, 1 },
                    { 3, 750m, 70m, 22m, "Paneer 150g + Dal + 2 Phulka", new DateTime(2025, 8, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Lunch", 45m, 1 },
                    { 4, 340m, 20m, 12m, "Tofu 150g + Veg Stir Fry", new DateTime(2025, 8, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Dinner", 30m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Progresses",
                columns: new[] { "ProgressId", "Arms", "BodyFat", "Chest", "Date", "Legs", "PhotoPath", "UserId", "Waist", "Weight" },
                values: new object[] { 1, 0m, 0m, 0m, new DateTime(2025, 8, 14, 0, 0, 0, 0, DateTimeKind.Utc), 0m, "", 1, 88m, 75m });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "WorkoutId", "DayOfWeek", "ExerciseName", "Focus", "Notes", "Reps", "Sets", "UserId", "WeekNumber" },
                values: new object[,]
                {
                    { 1, 1, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 1 },
                    { 2, 2, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 1 },
                    { 3, 3, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 1 },
                    { 4, 4, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 1 },
                    { 5, 5, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 1 },
                    { 6, 6, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 1 },
                    { 7, 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 1 },
                    { 8, 1, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 2 },
                    { 9, 2, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 2 },
                    { 10, 3, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 2 },
                    { 11, 4, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 2 },
                    { 12, 5, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 2 },
                    { 13, 6, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 2 },
                    { 14, 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 2 },
                    { 15, 1, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 3 },
                    { 16, 2, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 3 },
                    { 17, 3, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 3 },
                    { 18, 4, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 3 },
                    { 19, 5, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 3 },
                    { 20, 6, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 3 },
                    { 21, 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 3 },
                    { 22, 1, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 4 },
                    { 23, 2, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 4 },
                    { 24, 3, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 4 },
                    { 25, 4, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 4 },
                    { 26, 5, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 4 },
                    { 27, 6, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 4 },
                    { 28, 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 4 },
                    { 29, 1, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 5 },
                    { 30, 2, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 5 },
                    { 31, 3, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 5 },
                    { 32, 4, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 5 },
                    { 33, 5, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 5 },
                    { 34, 6, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 5 },
                    { 35, 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 5 },
                    { 36, 1, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 6 },
                    { 37, 2, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 6 },
                    { 38, 3, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 6 },
                    { 39, 4, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 6 },
                    { 40, 5, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 6 },
                    { 41, 6, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 6 },
                    { 42, 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 6 },
                    { 43, 1, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 7 },
                    { 44, 2, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 7 },
                    { 45, 3, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 7 },
                    { 46, 4, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 7 },
                    { 47, 5, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 7 },
                    { 48, 6, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 7 },
                    { 49, 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 7 },
                    { 50, 1, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 8 },
                    { 51, 2, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 8 },
                    { 52, 3, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 8 },
                    { 53, 4, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 8 },
                    { 54, 5, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 8 },
                    { 55, 6, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 8 },
                    { 56, 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 8 }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Completed", "Name", "Notes", "Reps", "Sets", "WorkoutDayId" },
                values: new object[,]
                {
                    { 1, false, "Bench Press", null, "12", 4, 1 },
                    { 2, false, "Incline DB Press", null, "12", 3, 1 },
                    { 3, false, "DB Fly", null, "15", 3, 1 },
                    { 4, false, "Triceps Pushdown", null, "12", 3, 1 },
                    { 5, false, "Overhead Extension", null, "12", 3, 1 },
                    { 6, false, "Lat Pulldown", null, "12", 4, 2 },
                    { 7, false, "Barbell Row", null, "12", 3, 2 },
                    { 8, false, "Seated Row", null, "12", 3, 2 },
                    { 9, false, "Bicep Curl", null, "12", 3, 2 },
                    { 10, false, "Hammer Curl", null, "12", 3, 2 },
                    { 11, false, "Squats", null, "12", 4, 3 },
                    { 12, false, "Lunges", null, "12", 3, 3 },
                    { 13, false, "Leg Press", null, "12", 3, 3 },
                    { 14, false, "Leg Curl", null, "15", 3, 3 },
                    { 15, false, "Plank", null, "45s", 3, 3 },
                    { 16, false, "Shoulder Press", null, "12", 4, 4 },
                    { 17, false, "Lateral Raise", null, "12", 3, 4 },
                    { 18, false, "Front Raise", null, "12", 3, 4 },
                    { 19, false, "Shrugs", null, "15", 3, 4 },
                    { 20, false, "Mountain Climbers", null, "30s", 3, 4 },
                    { 21, false, "Deadlifts", null, "12", 4, 5 },
                    { 22, false, "Push-Ups", null, "15", 3, 5 },
                    { 23, false, "Burpees", null, "12", 3, 5 },
                    { 24, false, "Battle Ropes", null, "30s", 3, 5 },
                    { 25, false, "HIIT Treadmill", null, "12", 3, 5 },
                    { 26, false, "Plank", null, "60s", 3, 6 },
                    { 27, false, "Side Plank", null, "30s each", 3, 6 },
                    { 28, false, "Russian Twist", null, "15", 3, 6 },
                    { 29, false, "Bicycle Crunch", null, "15", 3, 6 },
                    { 30, false, "Jogging", null, "12", 3, 6 },
                    { 31, false, "Walk + Stretch", null, "12", 3, 7 },
                    { 32, false, "Bench Press", null, "12", 4, 8 },
                    { 33, false, "Incline DB Press", null, "12", 3, 8 },
                    { 34, false, "DB Fly", null, "15", 3, 8 },
                    { 35, false, "Triceps Pushdown", null, "12", 3, 8 },
                    { 36, false, "Overhead Extension", null, "12", 3, 8 },
                    { 37, false, "Lat Pulldown", null, "12", 4, 9 },
                    { 38, false, "Barbell Row", null, "12", 3, 9 },
                    { 39, false, "Seated Row", null, "12", 3, 9 },
                    { 40, false, "Bicep Curl", null, "12", 3, 9 },
                    { 41, false, "Hammer Curl", null, "12", 3, 9 },
                    { 42, false, "Squats", null, "12", 4, 10 },
                    { 43, false, "Lunges", null, "12", 3, 10 },
                    { 44, false, "Leg Press", null, "12", 3, 10 },
                    { 45, false, "Leg Curl", null, "15", 3, 10 },
                    { 46, false, "Plank", null, "45s", 3, 10 },
                    { 47, false, "Shoulder Press", null, "12", 4, 11 },
                    { 48, false, "Lateral Raise", null, "12", 3, 11 },
                    { 49, false, "Front Raise", null, "12", 3, 11 },
                    { 50, false, "Shrugs", null, "15", 3, 11 },
                    { 51, false, "Mountain Climbers", null, "30s", 3, 11 },
                    { 52, false, "Deadlifts", null, "12", 4, 12 },
                    { 53, false, "Push-Ups", null, "15", 3, 12 },
                    { 54, false, "Burpees", null, "12", 3, 12 },
                    { 55, false, "Battle Ropes", null, "30s", 3, 12 },
                    { 56, false, "HIIT Treadmill", null, "12", 3, 12 },
                    { 57, false, "Plank", null, "60s", 3, 13 },
                    { 58, false, "Side Plank", null, "30s each", 3, 13 },
                    { 59, false, "Russian Twist", null, "15", 3, 13 },
                    { 60, false, "Bicycle Crunch", null, "15", 3, 13 },
                    { 61, false, "Jogging", null, "12", 3, 13 },
                    { 62, false, "Walk + Stretch", null, "12", 3, 14 },
                    { 63, false, "Bench Press", null, "12", 4, 15 },
                    { 64, false, "Incline DB Press", null, "12", 3, 15 },
                    { 65, false, "DB Fly", null, "15", 3, 15 },
                    { 66, false, "Triceps Pushdown", null, "12", 3, 15 },
                    { 67, false, "Overhead Extension", null, "12", 3, 15 },
                    { 68, false, "Lat Pulldown", null, "12", 4, 16 },
                    { 69, false, "Barbell Row", null, "12", 3, 16 },
                    { 70, false, "Seated Row", null, "12", 3, 16 },
                    { 71, false, "Bicep Curl", null, "12", 3, 16 },
                    { 72, false, "Hammer Curl", null, "12", 3, 16 },
                    { 73, false, "Squats", null, "12", 4, 17 },
                    { 74, false, "Lunges", null, "12", 3, 17 },
                    { 75, false, "Leg Press", null, "12", 3, 17 },
                    { 76, false, "Leg Curl", null, "15", 3, 17 },
                    { 77, false, "Plank", null, "45s", 3, 17 },
                    { 78, false, "Shoulder Press", null, "12", 4, 18 },
                    { 79, false, "Lateral Raise", null, "12", 3, 18 },
                    { 80, false, "Front Raise", null, "12", 3, 18 },
                    { 81, false, "Shrugs", null, "15", 3, 18 },
                    { 82, false, "Mountain Climbers", null, "30s", 3, 18 },
                    { 83, false, "Deadlifts", null, "12", 4, 19 },
                    { 84, false, "Push-Ups", null, "15", 3, 19 },
                    { 85, false, "Burpees", null, "12", 3, 19 },
                    { 86, false, "Battle Ropes", null, "30s", 3, 19 },
                    { 87, false, "HIIT Treadmill", null, "12", 3, 19 },
                    { 88, false, "Plank", null, "60s", 3, 20 },
                    { 89, false, "Side Plank", null, "30s each", 3, 20 },
                    { 90, false, "Russian Twist", null, "15", 3, 20 },
                    { 91, false, "Bicycle Crunch", null, "15", 3, 20 },
                    { 92, false, "Jogging", null, "12", 3, 20 },
                    { 93, false, "Walk + Stretch", null, "12", 3, 21 },
                    { 94, false, "Bench Press", null, "12", 4, 22 },
                    { 95, false, "Incline DB Press", null, "12", 3, 22 },
                    { 96, false, "DB Fly", null, "15", 3, 22 },
                    { 97, false, "Triceps Pushdown", null, "12", 3, 22 },
                    { 98, false, "Overhead Extension", null, "12", 3, 22 },
                    { 99, false, "Lat Pulldown", null, "12", 4, 23 },
                    { 100, false, "Barbell Row", null, "12", 3, 23 },
                    { 101, false, "Seated Row", null, "12", 3, 23 },
                    { 102, false, "Bicep Curl", null, "12", 3, 23 },
                    { 103, false, "Hammer Curl", null, "12", 3, 23 },
                    { 104, false, "Squats", null, "12", 4, 24 },
                    { 105, false, "Lunges", null, "12", 3, 24 },
                    { 106, false, "Leg Press", null, "12", 3, 24 },
                    { 107, false, "Leg Curl", null, "15", 3, 24 },
                    { 108, false, "Plank", null, "45s", 3, 24 },
                    { 109, false, "Shoulder Press", null, "12", 4, 25 },
                    { 110, false, "Lateral Raise", null, "12", 3, 25 },
                    { 111, false, "Front Raise", null, "12", 3, 25 },
                    { 112, false, "Shrugs", null, "15", 3, 25 },
                    { 113, false, "Mountain Climbers", null, "30s", 3, 25 },
                    { 114, false, "Deadlifts", null, "12", 4, 26 },
                    { 115, false, "Push-Ups", null, "15", 3, 26 },
                    { 116, false, "Burpees", null, "12", 3, 26 },
                    { 117, false, "Battle Ropes", null, "30s", 3, 26 },
                    { 118, false, "HIIT Treadmill", null, "12", 3, 26 },
                    { 119, false, "Plank", null, "60s", 3, 27 },
                    { 120, false, "Side Plank", null, "30s each", 3, 27 },
                    { 121, false, "Russian Twist", null, "15", 3, 27 },
                    { 122, false, "Bicycle Crunch", null, "15", 3, 27 },
                    { 123, false, "Jogging", null, "12", 3, 27 },
                    { 124, false, "Walk + Stretch", null, "12", 3, 28 },
                    { 125, false, "Bench Press", null, "12", 4, 29 },
                    { 126, false, "Incline DB Press", null, "12", 3, 29 },
                    { 127, false, "DB Fly", null, "15", 3, 29 },
                    { 128, false, "Triceps Pushdown", null, "12", 3, 29 },
                    { 129, false, "Overhead Extension", null, "12", 3, 29 },
                    { 130, false, "Lat Pulldown", null, "12", 4, 30 },
                    { 131, false, "Barbell Row", null, "12", 3, 30 },
                    { 132, false, "Seated Row", null, "12", 3, 30 },
                    { 133, false, "Bicep Curl", null, "12", 3, 30 },
                    { 134, false, "Hammer Curl", null, "12", 3, 30 },
                    { 135, false, "Squats", null, "12", 4, 31 },
                    { 136, false, "Lunges", null, "12", 3, 31 },
                    { 137, false, "Leg Press", null, "12", 3, 31 },
                    { 138, false, "Leg Curl", null, "15", 3, 31 },
                    { 139, false, "Plank", null, "45s", 3, 31 },
                    { 140, false, "Shoulder Press", null, "12", 4, 32 },
                    { 141, false, "Lateral Raise", null, "12", 3, 32 },
                    { 142, false, "Front Raise", null, "12", 3, 32 },
                    { 143, false, "Shrugs", null, "15", 3, 32 },
                    { 144, false, "Mountain Climbers", null, "30s", 3, 32 },
                    { 145, false, "Deadlifts", null, "12", 4, 33 },
                    { 146, false, "Push-Ups", null, "15", 3, 33 },
                    { 147, false, "Burpees", null, "12", 3, 33 },
                    { 148, false, "Battle Ropes", null, "30s", 3, 33 },
                    { 149, false, "HIIT Treadmill", null, "12", 3, 33 },
                    { 150, false, "Plank", null, "60s", 3, 34 },
                    { 151, false, "Side Plank", null, "30s each", 3, 34 },
                    { 152, false, "Russian Twist", null, "15", 3, 34 },
                    { 153, false, "Bicycle Crunch", null, "15", 3, 34 },
                    { 154, false, "Jogging", null, "12", 3, 34 },
                    { 155, false, "Walk + Stretch", null, "12", 3, 35 },
                    { 156, false, "Bench Press", null, "12", 4, 36 },
                    { 157, false, "Incline DB Press", null, "12", 3, 36 },
                    { 158, false, "DB Fly", null, "15", 3, 36 },
                    { 159, false, "Triceps Pushdown", null, "12", 3, 36 },
                    { 160, false, "Overhead Extension", null, "12", 3, 36 },
                    { 161, false, "Lat Pulldown", null, "12", 4, 37 },
                    { 162, false, "Barbell Row", null, "12", 3, 37 },
                    { 163, false, "Seated Row", null, "12", 3, 37 },
                    { 164, false, "Bicep Curl", null, "12", 3, 37 },
                    { 165, false, "Hammer Curl", null, "12", 3, 37 },
                    { 166, false, "Squats", null, "12", 4, 38 },
                    { 167, false, "Lunges", null, "12", 3, 38 },
                    { 168, false, "Leg Press", null, "12", 3, 38 },
                    { 169, false, "Leg Curl", null, "15", 3, 38 },
                    { 170, false, "Plank", null, "45s", 3, 38 },
                    { 171, false, "Shoulder Press", null, "12", 4, 39 },
                    { 172, false, "Lateral Raise", null, "12", 3, 39 },
                    { 173, false, "Front Raise", null, "12", 3, 39 },
                    { 174, false, "Shrugs", null, "15", 3, 39 },
                    { 175, false, "Mountain Climbers", null, "30s", 3, 39 },
                    { 176, false, "Deadlifts", null, "12", 4, 40 },
                    { 177, false, "Push-Ups", null, "15", 3, 40 },
                    { 178, false, "Burpees", null, "12", 3, 40 },
                    { 179, false, "Battle Ropes", null, "30s", 3, 40 },
                    { 180, false, "HIIT Treadmill", null, "12", 3, 40 },
                    { 181, false, "Plank", null, "60s", 3, 41 },
                    { 182, false, "Side Plank", null, "30s each", 3, 41 },
                    { 183, false, "Russian Twist", null, "15", 3, 41 },
                    { 184, false, "Bicycle Crunch", null, "15", 3, 41 },
                    { 185, false, "Jogging", null, "12", 3, 41 },
                    { 186, false, "Walk + Stretch", null, "12", 3, 42 },
                    { 187, false, "Bench Press", null, "12", 4, 43 },
                    { 188, false, "Incline DB Press", null, "12", 3, 43 },
                    { 189, false, "DB Fly", null, "15", 3, 43 },
                    { 190, false, "Triceps Pushdown", null, "12", 3, 43 },
                    { 191, false, "Overhead Extension", null, "12", 3, 43 },
                    { 192, false, "Lat Pulldown", null, "12", 4, 44 },
                    { 193, false, "Barbell Row", null, "12", 3, 44 },
                    { 194, false, "Seated Row", null, "12", 3, 44 },
                    { 195, false, "Bicep Curl", null, "12", 3, 44 },
                    { 196, false, "Hammer Curl", null, "12", 3, 44 },
                    { 197, false, "Squats", null, "12", 4, 45 },
                    { 198, false, "Lunges", null, "12", 3, 45 },
                    { 199, false, "Leg Press", null, "12", 3, 45 },
                    { 200, false, "Leg Curl", null, "15", 3, 45 },
                    { 201, false, "Plank", null, "45s", 3, 45 },
                    { 202, false, "Shoulder Press", null, "12", 4, 46 },
                    { 203, false, "Lateral Raise", null, "12", 3, 46 },
                    { 204, false, "Front Raise", null, "12", 3, 46 },
                    { 205, false, "Shrugs", null, "15", 3, 46 },
                    { 206, false, "Mountain Climbers", null, "30s", 3, 46 },
                    { 207, false, "Deadlifts", null, "12", 4, 47 },
                    { 208, false, "Push-Ups", null, "15", 3, 47 },
                    { 209, false, "Burpees", null, "12", 3, 47 },
                    { 210, false, "Battle Ropes", null, "30s", 3, 47 },
                    { 211, false, "HIIT Treadmill", null, "12", 3, 47 },
                    { 212, false, "Plank", null, "60s", 3, 48 },
                    { 213, false, "Side Plank", null, "30s each", 3, 48 },
                    { 214, false, "Russian Twist", null, "15", 3, 48 },
                    { 215, false, "Bicycle Crunch", null, "15", 3, 48 },
                    { 216, false, "Jogging", null, "12", 3, 48 },
                    { 217, false, "Walk + Stretch", null, "12", 3, 49 },
                    { 218, false, "Bench Press", null, "12", 4, 50 },
                    { 219, false, "Incline DB Press", null, "12", 3, 50 },
                    { 220, false, "DB Fly", null, "15", 3, 50 },
                    { 221, false, "Triceps Pushdown", null, "12", 3, 50 },
                    { 222, false, "Overhead Extension", null, "12", 3, 50 },
                    { 223, false, "Lat Pulldown", null, "12", 4, 51 },
                    { 224, false, "Barbell Row", null, "12", 3, 51 },
                    { 225, false, "Seated Row", null, "12", 3, 51 },
                    { 226, false, "Bicep Curl", null, "12", 3, 51 },
                    { 227, false, "Hammer Curl", null, "12", 3, 51 },
                    { 228, false, "Squats", null, "12", 4, 52 },
                    { 229, false, "Lunges", null, "12", 3, 52 },
                    { 230, false, "Leg Press", null, "12", 3, 52 },
                    { 231, false, "Leg Curl", null, "15", 3, 52 },
                    { 232, false, "Plank", null, "45s", 3, 52 },
                    { 233, false, "Shoulder Press", null, "12", 4, 53 },
                    { 234, false, "Lateral Raise", null, "12", 3, 53 },
                    { 235, false, "Front Raise", null, "12", 3, 53 },
                    { 236, false, "Shrugs", null, "15", 3, 53 },
                    { 237, false, "Mountain Climbers", null, "30s", 3, 53 },
                    { 238, false, "Deadlifts", null, "12", 4, 54 },
                    { 239, false, "Push-Ups", null, "15", 3, 54 },
                    { 240, false, "Burpees", null, "12", 3, 54 },
                    { 241, false, "Battle Ropes", null, "30s", 3, 54 },
                    { 242, false, "HIIT Treadmill", null, "12", 3, 54 },
                    { 243, false, "Plank", null, "60s", 3, 55 },
                    { 244, false, "Side Plank", null, "30s each", 3, 55 },
                    { 245, false, "Russian Twist", null, "15", 3, 55 },
                    { 246, false, "Bicycle Crunch", null, "15", 3, 55 },
                    { 247, false, "Jogging", null, "12", 3, 55 },
                    { 248, false, "Walk + Stretch", null, "12", 3, 56 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_WorkoutDayId",
                table: "Exercises",
                column: "WorkoutDayId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_UserId",
                table: "Meals",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DeleteData(
                table: "Progresses",
                keyColumn: "ProgressId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Focus",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "WeekNumber",
                table: "Workouts");

            migrationBuilder.CreateTable(
                name: "DietPlans",
                columns: table => new
                {
                    DietId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Calories = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Carbs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fats = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FoodItem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MealTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Protein = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietPlans", x => x.DietId);
                    table.ForeignKey(
                        name: "FK_DietPlans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DietPlans_UserId",
                table: "DietPlans",
                column: "UserId");
        }
    }
}
