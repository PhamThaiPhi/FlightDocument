using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intern_Alta.Migrations
{
    public partial class dbudate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentID",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentID",
                table: "Flights");
        }
    }
}
