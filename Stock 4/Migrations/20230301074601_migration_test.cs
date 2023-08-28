using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stock_4.Migrations
{
    public partial class migration_test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWatchlist1_authorizedUsers_UserId",
                table: "UserWatchlist1");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWatchlist1_stockLists_StockId",
                table: "UserWatchlist1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWatchlist1",
                table: "UserWatchlist1");

            migrationBuilder.RenameTable(
                name: "UserWatchlist1",
                newName: "userWatchlist1s");

            migrationBuilder.RenameIndex(
                name: "IX_UserWatchlist1_UserId",
                table: "userWatchlist1s",
                newName: "IX_userWatchlist1s_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserWatchlist1_StockId",
                table: "userWatchlist1s",
                newName: "IX_userWatchlist1s_StockId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userWatchlist1s",
                table: "userWatchlist1s",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "API_HolidayLocal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Occasion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API_HolidayLocal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalcAPI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Stockprice = table.Column<float>(type: "real", nullable: false),
                    StampDuty = table.Column<int>(type: "int", nullable: false),
                    Brokerage = table.Column<float>(type: "real", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalcAPI", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_userWatchlist1s_authorizedUsers_UserId",
                table: "userWatchlist1s",
                column: "UserId",
                principalTable: "authorizedUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userWatchlist1s_stockLists_StockId",
                table: "userWatchlist1s",
                column: "StockId",
                principalTable: "stockLists",
                principalColumn: "StockId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userWatchlist1s_authorizedUsers_UserId",
                table: "userWatchlist1s");

            migrationBuilder.DropForeignKey(
                name: "FK_userWatchlist1s_stockLists_StockId",
                table: "userWatchlist1s");

            migrationBuilder.DropTable(
                name: "API_HolidayLocal");

            migrationBuilder.DropTable(
                name: "CalcAPI");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userWatchlist1s",
                table: "userWatchlist1s");

            migrationBuilder.RenameTable(
                name: "userWatchlist1s",
                newName: "UserWatchlist1");

            migrationBuilder.RenameIndex(
                name: "IX_userWatchlist1s_UserId",
                table: "UserWatchlist1",
                newName: "IX_UserWatchlist1_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_userWatchlist1s_StockId",
                table: "UserWatchlist1",
                newName: "IX_UserWatchlist1_StockId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserWatchlist1",
                table: "UserWatchlist1",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWatchlist1_authorizedUsers_UserId",
                table: "UserWatchlist1",
                column: "UserId",
                principalTable: "authorizedUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWatchlist1_stockLists_StockId",
                table: "UserWatchlist1",
                column: "StockId",
                principalTable: "stockLists",
                principalColumn: "StockId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
