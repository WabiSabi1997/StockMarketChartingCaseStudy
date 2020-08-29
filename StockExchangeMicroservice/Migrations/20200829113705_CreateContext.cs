using Microsoft.EntityFrameworkCore.Migrations;

namespace StockExchangeMicroservice.Migrations
{
    public partial class CreateContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sector",
                columns: table => new
                {
                    SectorID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorName = table.Column<string>(nullable: false),
                    Brief = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.SectorID);
                });

            migrationBuilder.CreateTable(
                name: "StockExchanges",
                columns: table => new
                {
                    StockExchangeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockExchangeName = table.Column<string>(nullable: false),
                    Brief = table.Column<string>(nullable: true),
                    ContactAddress = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockExchanges", x => x.StockExchangeID);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true),
                    Turnover = table.Column<double>(nullable: false),
                    CEO = table.Column<string>(nullable: true),
                    Brief = table.Column<string>(nullable: true),
                    SectorID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Companies_Sector_SectorID",
                        column: x => x.SectorID,
                        principalTable: "Sector",
                        principalColumn: "SectorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IPODetail",
                columns: table => new
                {
                    IPODetailID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PricePerShare = table.Column<decimal>(nullable: false),
                    TotalNumOfShares = table.Column<int>(nullable: false),
                    OpenDate = table.Column<string>(nullable: false),
                    OpenTime = table.Column<string>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    StockExchangeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPODetail", x => x.IPODetailID);
                    table.ForeignKey(
                        name: "FK_IPODetail_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IPODetail_StockExchanges_StockExchangeId",
                        column: x => x.StockExchangeId,
                        principalTable: "StockExchanges",
                        principalColumn: "StockExchangeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockExchangeCompanies",
                columns: table => new
                {
                    StockExchangeId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockExchangeCompanies", x => new { x.StockExchangeId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_StockExchangeCompanies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockExchangeCompanies_StockExchanges_StockExchangeId",
                        column: x => x.StockExchangeId,
                        principalTable: "StockExchanges",
                        principalColumn: "StockExchangeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockPrice",
                columns: table => new
                {
                    StockPriceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentPrice = table.Column<decimal>(nullable: false),
                    Date = table.Column<string>(nullable: false),
                    Time = table.Column<string>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    StockExchangeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockPrice", x => x.StockPriceId);
                    table.ForeignKey(
                        name: "FK_StockPrice_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockPrice_StockExchanges_StockExchangeId",
                        column: x => x.StockExchangeId,
                        principalTable: "StockExchanges",
                        principalColumn: "StockExchangeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_SectorID",
                table: "Companies",
                column: "SectorID");

            migrationBuilder.CreateIndex(
                name: "IX_IPODetail_CompanyId",
                table: "IPODetail",
                column: "CompanyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IPODetail_StockExchangeId",
                table: "IPODetail",
                column: "StockExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_StockExchangeCompanies_CompanyId",
                table: "StockExchangeCompanies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_StockPrice_CompanyId",
                table: "StockPrice",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_StockPrice_StockExchangeId",
                table: "StockPrice",
                column: "StockExchangeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IPODetail");

            migrationBuilder.DropTable(
                name: "StockExchangeCompanies");

            migrationBuilder.DropTable(
                name: "StockPrice");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "StockExchanges");

            migrationBuilder.DropTable(
                name: "Sector");
        }
    }
}
