using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intern_Alta.Migrations
{
    public partial class DBupdate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Configuration_Configuration_ConfigurationConfigID",
                table: "Configuration");

            migrationBuilder.DropForeignKey(
                name: "FK_Configuration_Permissions_DocumentTypeID",
                table: "Configuration");

            migrationBuilder.DropIndex(
                name: "IX_Configuration_ConfigurationConfigID",
                table: "Configuration");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ConfigurationConfigID",
                table: "Configuration");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Configuration");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_PermissionID",
                table: "Configuration",
                column: "PermissionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Configuration_Permissions_PermissionID",
                table: "Configuration",
                column: "PermissionID",
                principalTable: "Permissions",
                principalColumn: "PermissionID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Configuration_Permissions_PermissionID",
                table: "Configuration");

            migrationBuilder.DropIndex(
                name: "IX_Configuration_PermissionID",
                table: "Configuration");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ConfigurationConfigID",
                table: "Configuration",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Configuration",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_ConfigurationConfigID",
                table: "Configuration",
                column: "ConfigurationConfigID");

            migrationBuilder.AddForeignKey(
                name: "FK_Configuration_Configuration_ConfigurationConfigID",
                table: "Configuration",
                column: "ConfigurationConfigID",
                principalTable: "Configuration",
                principalColumn: "ConfigID");

            migrationBuilder.AddForeignKey(
                name: "FK_Configuration_Permissions_DocumentTypeID",
                table: "Configuration",
                column: "DocumentTypeID",
                principalTable: "Permissions",
                principalColumn: "PermissionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
