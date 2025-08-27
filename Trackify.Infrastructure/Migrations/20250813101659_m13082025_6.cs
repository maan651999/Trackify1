using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trackify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class m13082025_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCategories_BudgetRecommendations_BudgetRecommendationId",
                table: "BudgetCategories");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Expenses",
                newName: "ExpenseId");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "BudgetRecommendations",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "BudgetRecommendations",
                newName: "RecommendationId");

            migrationBuilder.RenameColumn(
                name: "BudgetRecommendationId",
                table: "BudgetCategories",
                newName: "RecommendationId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BudgetCategories",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetCategories_BudgetRecommendationId",
                table: "BudgetCategories",
                newName: "IX_BudgetCategories_RecommendationId");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetCategories_BudgetRecommendations_RecommendationId",
                table: "BudgetCategories",
                column: "RecommendationId",
                principalTable: "BudgetRecommendations",
                principalColumn: "RecommendationId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCategories_BudgetRecommendations_RecommendationId",
                table: "BudgetCategories");

            migrationBuilder.RenameColumn(
                name: "ExpenseId",
                table: "Expenses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "BudgetRecommendations",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "RecommendationId",
                table: "BudgetRecommendations",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "RecommendationId",
                table: "BudgetCategories",
                newName: "BudgetRecommendationId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "BudgetCategories",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetCategories_RecommendationId",
                table: "BudgetCategories",
                newName: "IX_BudgetCategories_BudgetRecommendationId");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetCategories_BudgetRecommendations_BudgetRecommendationId",
                table: "BudgetCategories",
                column: "BudgetRecommendationId",
                principalTable: "BudgetRecommendations",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
