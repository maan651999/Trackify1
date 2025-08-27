using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trackify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _14082025_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Progresses",
                keyColumn: "ProgressId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 14, 8, 58, 56, 519, DateTimeKind.Utc).AddTicks(9730));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Progresses",
                keyColumn: "ProgressId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 8, 14, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 14, 8, 56, 52, 559, DateTimeKind.Utc).AddTicks(2036));
        }
    }
}
