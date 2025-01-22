using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intern_Alta.Migrations
{
    public partial class add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "DocumentTypes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Departure",
                table: "Flights",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadedAt",
                table: "Documents",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "ConfigurationConfigID",
                table: "Configuration",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocumentTypeID",
                table: "Configuration",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PermissionID",
                table: "Configuration",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_ConfigurationConfigID",
                table: "Configuration",
                column: "ConfigurationConfigID");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_DocumentTypeID",
                table: "Configuration",
                column: "DocumentTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Configuration_Configuration_ConfigurationConfigID",
                table: "Configuration",
                column: "ConfigurationConfigID",
                principalTable: "Configuration",
                principalColumn: "ConfigID");

            migrationBuilder.AddForeignKey(
                name: "FK_Configuration_DocumentTypes_DocumentTypeID",
                table: "Configuration",
                column: "DocumentTypeID",
                principalTable: "DocumentTypes",
                principalColumn: "DocumentTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Configuration_Permissions_DocumentTypeID",
                table: "Configuration",
                column: "DocumentTypeID",
                principalTable: "Permissions",
                principalColumn: "PermissionID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Configuration_Configuration_ConfigurationConfigID",
                table: "Configuration");

            migrationBuilder.DropForeignKey(
                name: "FK_Configuration_DocumentTypes_DocumentTypeID",
                table: "Configuration");

            migrationBuilder.DropForeignKey(
                name: "FK_Configuration_Permissions_DocumentTypeID",
                table: "Configuration");

            migrationBuilder.DropIndex(
                name: "IX_Configuration_ConfigurationConfigID",
                table: "Configuration");

            migrationBuilder.DropIndex(
                name: "IX_Configuration_DocumentTypeID",
                table: "Configuration");

            migrationBuilder.DropColumn(
                name: "ConfigurationConfigID",
                table: "Configuration");

            migrationBuilder.DropColumn(
                name: "DocumentTypeID",
                table: "Configuration");

            migrationBuilder.DropColumn(
                name: "PermissionID",
                table: "Configuration");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Departure",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "DocumentTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadedAt",
                table: "Documents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
