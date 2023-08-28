using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalcApiLocal.Migrations
{
    public partial class _006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Brokerage",
                table: "calcRes",
                type: "real",
                nullable: false,
                defaultValue: 1f);

            migrationBuilder.AddColumn<int>(
                name: "StampDuty",
                table: "calcRes",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<float>(
                name: "TotalPrice",
                table: "calcRes",
                type: "real",
                nullable: false,
                defaultValue: 1f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
