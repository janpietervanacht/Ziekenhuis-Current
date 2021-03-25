using Microsoft.EntityFrameworkCore.Migrations;

namespace Ziekenhuis.DataAccess.Migrations
{
    public partial class VerzendStatusFactuur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SendYN",
                table: "Invoices",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "NumberRanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinClientNumber = table.Column<int>(nullable: false),
                    MaxClientNumber = table.Column<int>(nullable: false),
                    CurrentClientNumber = table.Column<int>(nullable: false),
                    MinInvoiceNumber = table.Column<int>(nullable: false),
                    MaxInvoiceNumber = table.Column<int>(nullable: false),
                    CurrentInvoiceNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberRanges", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NumberRanges");

            migrationBuilder.DropColumn(
                name: "SendYN",
                table: "Invoices");
        }
    }
}
