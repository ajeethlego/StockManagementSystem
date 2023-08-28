using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalcApiLocal.Migrations
{
    public partial class _005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brokerage",
                table: "calcRes");

            migrationBuilder.DropColumn(
                name: "StampDuty",
                table: "calcRes");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "calcRes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Brokerage",
                table: "calcRes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "StampDuty",
                table: "calcRes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "TotalPrice",
                table: "calcRes",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
