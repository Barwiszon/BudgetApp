﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetApp.Migrations
{
    /// <inheritdoc />
    public partial class AddFamilyTransferRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyTransfers_AspNetUsers_FromUserId",
                table: "FamilyTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyTransfers_AspNetUsers_ToUserId",
                table: "FamilyTransfers");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyTransfers_AspNetUsers_FromUserId",
                table: "FamilyTransfers",
                column: "FromUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyTransfers_AspNetUsers_ToUserId",
                table: "FamilyTransfers",
                column: "ToUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyTransfers_AspNetUsers_FromUserId",
                table: "FamilyTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyTransfers_AspNetUsers_ToUserId",
                table: "FamilyTransfers");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyTransfers_AspNetUsers_FromUserId",
                table: "FamilyTransfers",
                column: "FromUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyTransfers_AspNetUsers_ToUserId",
                table: "FamilyTransfers",
                column: "ToUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
