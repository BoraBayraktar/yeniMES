using Microsoft.EntityFrameworkCore.Migrations;

namespace MES.DB.Migrations
{
    public partial class MES8_UserCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "COMPANY_ID",
                table: "USER",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_USER_COMPANY_ID",
                table: "USER",
                column: "COMPANY_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_USER_COMPANY_COMPANY_ID",
                table: "USER",
                column: "COMPANY_ID",
                principalTable: "COMPANY",
                principalColumn: "COMPANY_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USER_COMPANY_COMPANY_ID",
                table: "USER");

            migrationBuilder.DropIndex(
                name: "IX_USER_COMPANY_ID",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "COMPANY_ID",
                table: "USER");
        }
    }
}
