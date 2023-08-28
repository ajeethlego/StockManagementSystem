using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalcApiLocal.Migrations
{
    public partial class _004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StampDuty",
                table: "calcRes",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StampDuty",
                table: "calcRes");
        }
    }
}
