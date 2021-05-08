using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persitence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "SnackSequence",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "SnackMachines",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    MoneyInside_OneCentCount = table.Column<int>(nullable: true),
                    MoneyInside_TenCentCount = table.Column<int>(nullable: true),
                    MoneyInside_QuarterCount = table.Column<int>(nullable: true),
                    MoneyInside_OneDollarCount = table.Column<int>(nullable: true),
                    MoneyInside_FiveDollarCount = table.Column<int>(nullable: true),
                    MoneyInside_TwentyDollarCount = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnackMachines", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SnackMachines");

            migrationBuilder.DropSequence(
                name: "SnackSequence");
        }
    }
}
