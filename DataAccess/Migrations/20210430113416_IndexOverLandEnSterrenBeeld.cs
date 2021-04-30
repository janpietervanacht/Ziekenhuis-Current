using Microsoft.EntityFrameworkCore.Migrations;

namespace Ziekenhuis.DataAccess.Migrations
{
    public partial class IndexOverLandEnSterrenBeeld : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clients_CountryId",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "AstrologyZodiacSign",
                table: "Clients",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "Index_CountryId_AstrologyZodiacSign",
                table: "Clients",
                columns: new[] { "CountryId", "AstrologyZodiacSign" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Index_CountryId_AstrologyZodiacSign",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "AstrologyZodiacSign",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CountryId",
                table: "Clients",
                column: "CountryId");
        }
    }
}
