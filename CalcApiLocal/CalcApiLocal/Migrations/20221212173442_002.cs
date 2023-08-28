using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalcApiLocal.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StampDuty",
                table: "calcRes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StampDuty",
                table: "calcRes");
        }
    }
}
