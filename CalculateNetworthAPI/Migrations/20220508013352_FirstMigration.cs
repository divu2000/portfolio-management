using Microsoft.EntityFrameworkCore.Migrations;

namespace CalculateNetworth.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetSaleResponses",
                columns: table => new
                {
                    ResponseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleStatus = table.Column<bool>(type: "bit", nullable: false),
                    NetWorth = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetSaleResponses", x => x.ResponseId);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioDetails",
                columns: table => new
                {
                    PortfolioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioDetails", x => x.PortfolioId);
                });

            migrationBuilder.CreateTable(
                name: "MutualFundDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MutualFundName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MutualFundUnits = table.Column<int>(type: "int", nullable: false),
                    PortfolioDetailPortfolioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MutualFundDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MutualFundDetails_PortfolioDetails_PortfolioDetailPortfolioId",
                        column: x => x.PortfolioDetailPortfolioId,
                        principalTable: "PortfolioDetails",
                        principalColumn: "PortfolioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Profile_Id = table.Column<int>(type: "int", nullable: false),
                    StockName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockCount = table.Column<int>(type: "int", nullable: false),
                    PortfolioDetailPortfolioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockInfo_PortfolioDetails_PortfolioDetailPortfolioId",
                        column: x => x.PortfolioDetailPortfolioId,
                        principalTable: "PortfolioDetails",
                        principalColumn: "PortfolioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MutualFundDetails_PortfolioDetailPortfolioId",
                table: "MutualFundDetails",
                column: "PortfolioDetailPortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_StockInfo_PortfolioDetailPortfolioId",
                table: "StockInfo",
                column: "PortfolioDetailPortfolioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetSaleResponses");

            migrationBuilder.DropTable(
                name: "MutualFundDetails");

            migrationBuilder.DropTable(
                name: "StockInfo");

            migrationBuilder.DropTable(
                name: "PortfolioDetails");
        }
    }
}
