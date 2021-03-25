using Microsoft.EntityFrameworkCore.Migrations;

namespace Ziekenhuis.DataAccess.Migrations
{
    public partial class uspDeleteCodeFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[uspDeleteClientByClientNumber]
                    @ClientNumber int
                AS
                BEGIN
                    SET NOCOUNT ON;
                    delete from Clients where ClientNumber = @ClientNumber
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
