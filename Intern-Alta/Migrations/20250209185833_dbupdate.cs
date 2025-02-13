using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intern_Alta.Migrations
{
    public partial class dbupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlightsID",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_FlightsID",
                table: "Documents",
                column: "FlightsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Flights_FlightsID",
                table: "Documents",
                column: "FlightsID",
                principalTable: "Flights",
                principalColumn: "FlightsID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Flights_FlightsID",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_FlightsID",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "FlightsID",
                table: "Documents");
        }
    }
}
