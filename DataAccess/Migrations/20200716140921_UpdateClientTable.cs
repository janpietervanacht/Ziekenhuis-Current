using Microsoft.EntityFrameworkCore.Migrations;

namespace Ziekenhuis.DataAccess.Migrations
{
    public partial class UpdateClientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Client",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Client_DoctorId",
                table: "Client",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Doctor_DoctorId",
                table: "Client",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction); 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Doctor_DoctorId",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_DoctorId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Client");
        }
    }
}
