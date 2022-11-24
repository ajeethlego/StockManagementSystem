using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stock_4.Migrations
{
    public partial class ProfOrLoss_column_in_portfolio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "ProfOrLoss",
                table: "userPortfolios",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfOrLoss",
                table: "userPortfolios");
        }
    }
}
