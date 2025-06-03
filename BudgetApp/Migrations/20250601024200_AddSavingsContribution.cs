using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetApp.Migrations
{
    /// <inheritdoc />
    public partial class AddSavingsContribution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SavingsContribution",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    SavingsGoalId = table.Column<int>(type: "INTEGER", nullable: false),
                    SavingsContributionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingsContribution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavingsContribution_SavingsContribution_SavingsContributionId",
                        column: x => x.SavingsContributionId,
                        principalTable: "SavingsContribution",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SavingsContribution_SavingsGoals_SavingsGoalId",
                        column: x => x.SavingsGoalId,
                        principalTable: "SavingsGoals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SavingsContribution_SavingsContributionId",
                table: "SavingsContribution",
                column: "SavingsContributionId");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsContribution_SavingsGoalId",
                table: "SavingsContribution",
                column: "SavingsGoalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SavingsContribution");
        }
    }
}
