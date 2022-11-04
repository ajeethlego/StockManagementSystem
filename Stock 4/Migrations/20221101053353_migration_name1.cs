using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stock_4.Migrations
{
    public partial class migration_name1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adminDetails",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adminDetails", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "authorizedUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PanNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncomePerAnum = table.Column<int>(type: "int", nullable: false),
                    EmploymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<int>(type: "int", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authorizedUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "stockLists",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stockLists", x => x.StockId);
                });

            migrationBuilder.CreateTable(
                name: "UserWatchlist1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWatchlist1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserWatchlist1_authorizedUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "authorizedUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWatchlist1_stockLists_StockId",
                        column: x => x.StockId,
                        principalTable: "stockLists",
                        principalColumn: "StockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserWatchlist1_StockId",
                table: "UserWatchlist1",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWatchlist1_UserId",
                table: "UserWatchlist1",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adminDetails");

            migrationBuilder.DropTable(
                name: "UserWatchlist1");

            migrationBuilder.DropTable(
                name: "authorizedUsers");

            migrationBuilder.DropTable(
                name: "stockLists");
        }
    }
}
