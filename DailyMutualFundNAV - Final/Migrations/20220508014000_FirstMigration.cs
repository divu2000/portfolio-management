using Microsoft.EntityFrameworkCore.Migrations;

namespace DailyMutualFundNAV.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MutualFunds",
                columns: table => new
                {
                    MutualFundId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MutualFundName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MutualFundValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MutualFunds", x => x.MutualFundId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MutualFunds");
        }
    }
}
