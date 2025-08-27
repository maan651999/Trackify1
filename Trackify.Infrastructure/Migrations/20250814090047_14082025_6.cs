using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trackify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _14082025_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "DietId",
                keyValue: 1,
                column: "MealTime",
                value: new DateTime(2025, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "DietId",
                keyValue: 2,
                column: "MealTime",
                value: new DateTime(2025, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "DietId",
                keyValue: 3,
                column: "MealTime",
                value: new DateTime(2025, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "DietId",
                keyValue: 4,
                column: "MealTime",
                value: new DateTime(2025, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "DietId",
                keyValue: 1,
                column: "MealTime",
                value: new DateTime(2025, 8, 14, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "DietId",
                keyValue: 2,
                column: "MealTime",
                value: new DateTime(2025, 8, 14, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "DietId",
                keyValue: 3,
                column: "MealTime",
                value: new DateTime(2025, 8, 14, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "DietId",
                keyValue: 4,
                column: "MealTime",
                value: new DateTime(2025, 8, 14, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 14, 8, 58, 56, 519, DateTimeKind.Utc).AddTicks(9730));
        }
    }
}
