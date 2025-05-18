using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetApp.Migrations
{
    /// <inheritdoc />
    public partial class FamilyManagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InviteeEmail",
                table: "Invites");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "Invites",
                newName: "Email");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Invites",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Invites",
                newName: "Token");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Invites",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "InviteeEmail",
                table: "Invites",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
