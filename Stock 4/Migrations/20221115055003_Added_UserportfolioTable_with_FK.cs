using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stock_4.Migrations
{
    public partial class Added_UserportfolioTable_with_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "userPortfolios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    BoughtAt = table.Column<int>(type: "int", nullable: false),
                    BoughtAtTotal = table.Column<long>(type: "bigint", nullable: false),
                    CurrentPrice = table.Column<int>(type: "int", nullable: false),
                    CurrentPriceTotal = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userPortfolios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userPortfolios_authorizedUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "authorizedUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userPortfolios_stockLists_StockId",
                        column: x => x.StockId,
                        principalTable: "stockLists",
                        principalColumn: "StockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userPortfolios_StockId",
                table: "userPortfolios",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_userPortfolios_UserId",
                table: "userPortfolios",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userPortfolios");
        }
    }
}
