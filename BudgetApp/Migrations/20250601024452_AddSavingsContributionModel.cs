using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetApp.Migrations
{
    /// <inheritdoc />
    public partial class AddSavingsContributionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavingsContribution_SavingsContribution_SavingsContributionId",
                table: "SavingsContribution");

            migrationBuilder.DropForeignKey(
                name: "FK_SavingsContribution_SavingsGoals_SavingsGoalId",
                table: "SavingsContribution");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavingsContribution",
                table: "SavingsContribution");

            migrationBuilder.DropIndex(
                name: "IX_SavingsContribution_SavingsContributionId",
                table: "SavingsContribution");

            migrationBuilder.DropColumn(
                name: "SavingsContributionId",
                table: "SavingsContribution");

            migrationBuilder.RenameTable(
                name: "SavingsContribution",
                newName: "SavingsContributions");

            migrationBuilder.RenameIndex(
                name: "IX_SavingsContribution_SavingsGoalId",
                table: "SavingsContributions",
                newName: "IX_SavingsContributions_SavingsGoalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavingsContributions",
                table: "SavingsContributions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SavingsContributions_SavingsGoals_SavingsGoalId",
                table: "SavingsContributions",
                column: "SavingsGoalId",
                principalTable: "SavingsGoals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavingsContributions_SavingsGoals_SavingsGoalId",
                table: "SavingsContributions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavingsContributions",
                table: "SavingsContributions");

            migrationBuilder.RenameTable(
                name: "SavingsContributions",
                newName: "SavingsContribution");

            migrationBuilder.RenameIndex(
                name: "IX_SavingsContributions_SavingsGoalId",
                table: "SavingsContribution",
                newName: "IX_SavingsContribution_SavingsGoalId");

            migrationBuilder.AddColumn<int>(
                name: "SavingsContributionId",
                table: "SavingsContribution",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavingsContribution",
                table: "SavingsContribution",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsContribution_SavingsContributionId",
                table: "SavingsContribution",
                column: "SavingsContributionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SavingsContribution_SavingsContribution_SavingsContributionId",
                table: "SavingsContribution",
                column: "SavingsContributionId",
                principalTable: "SavingsContribution",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SavingsContribution_SavingsGoals_SavingsGoalId",
                table: "SavingsContribution",
                column: "SavingsGoalId",
                principalTable: "SavingsGoals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
