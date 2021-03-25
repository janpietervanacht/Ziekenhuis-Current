using Microsoft.EntityFrameworkCore.Migrations;

namespace Ziekenhuis.DataAccess.Migrations
{
    public partial class IndexOpFactuurNummer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "NumberRanges",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        MinClientNumber = table.Column<int>(nullable: false),
            //        MaxClientNumber = table.Column<int>(nullable: false),
            //        CurrentClientNumber = table.Column<int>(nullable: false),
            //        MinInvoiceNumber = table.Column<int>(nullable: false),
            //        MaxInvoiceNumber = table.Column<int>(nullable: false),
            //        CurrentInvoiceNumber = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_NumberRanges", x => x.Id);
            //    });

            migrationBuilder.CreateIndex(
                name: "Index_InvoiceNumber",
                table: "Invoices",
                column: "InvoiceNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Index_InvoiceNumber",
                table: "Invoices");
        }
    }
}
