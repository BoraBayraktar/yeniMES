using Microsoft.EntityFrameworkCore.Migrations;

namespace MES.DB.Migrations
{
    public partial class MES6_ServiceCatalogCreatedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "SERVICECATALOG",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "SERVICECATALOG",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SERVICECATALOG_CREATED_USER_ID",
                table: "SERVICECATALOG",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICECATALOG_UPDATED_USER_ID",
                table: "SERVICECATALOG",
                column: "UPDATED_USER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SERVICECATALOG_USER_CREATED_USER_ID",
                table: "SERVICECATALOG",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SERVICECATALOG_USER_UPDATED_USER_ID",
                table: "SERVICECATALOG",
                column: "UPDATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SERVICECATALOG_USER_CREATED_USER_ID",
                table: "SERVICECATALOG");

            migrationBuilder.DropForeignKey(
                name: "FK_SERVICECATALOG_USER_UPDATED_USER_ID",
                table: "SERVICECATALOG");

            migrationBuilder.DropIndex(
                name: "IX_SERVICECATALOG_CREATED_USER_ID",
                table: "SERVICECATALOG");

            migrationBuilder.DropIndex(
                name: "IX_SERVICECATALOG_UPDATED_USER_ID",
                table: "SERVICECATALOG");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "SERVICECATALOG");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "SERVICECATALOG");
        }
    }
}
