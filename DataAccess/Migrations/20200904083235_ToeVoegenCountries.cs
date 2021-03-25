using Microsoft.EntityFrameworkCore.Migrations;

namespace Ziekenhuis.DataAccess.Migrations
{
    public partial class ToeVoegenCountries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SortNumber = table.Column<int>(nullable: false),
                    CountryCodeISO = table.Column<string>(nullable: false),
                    CountryDescription = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
