using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetApp.Migrations
{
    /// <inheritdoc />
    public partial class AddFamilyIdToSavingsGoal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FamilyId",
                table: "SavingsGoals",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsShared",
                table: "SavingsGoals",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_SavingsGoals_FamilyId",
                table: "SavingsGoals",
                column: "FamilyId");

            migrationBuilder.AddForeignKey(
                name: "FK_SavingsGoals_Families_FamilyId",
                table: "SavingsGoals",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavingsGoals_Families_FamilyId",
                table: "SavingsGoals");

            migrationBuilder.DropIndex(
                name: "IX_SavingsGoals_FamilyId",
                table: "SavingsGoals");

            migrationBuilder.DropColumn(
                name: "FamilyId",
                table: "SavingsGoals");

            migrationBuilder.DropColumn(
                name: "IsShared",
                table: "SavingsGoals");
        }
    }
}
