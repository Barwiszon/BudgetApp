using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetApp.Migrations
{
    /// <inheritdoc />
    public partial class AddAutoDepositFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AutoDepositAmount",
                table: "SavingsGoals",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "AutoDepositEnabled",
                table: "SavingsGoals",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AutoDepositIntervalDays",
                table: "SavingsGoals",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastAutoDepositDate",
                table: "SavingsGoals",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutoDepositAmount",
                table: "SavingsGoals");

            migrationBuilder.DropColumn(
                name: "AutoDepositEnabled",
                table: "SavingsGoals");

            migrationBuilder.DropColumn(
                name: "AutoDepositIntervalDays",
                table: "SavingsGoals");

            migrationBuilder.DropColumn(
                name: "LastAutoDepositDate",
                table: "SavingsGoals");
        }
    }
}
