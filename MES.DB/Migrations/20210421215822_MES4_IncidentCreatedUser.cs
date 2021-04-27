using Microsoft.EntityFrameworkCore.Migrations;

namespace MES.DB.Migrations
{
    public partial class MES4_IncidentCreatedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "INCIDENT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "INCIDENT",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_CREATED_USER_ID",
                table: "INCIDENT",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_UPDATED_USER_ID",
                table: "INCIDENT",
                column: "UPDATED_USER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_INCIDENT_USER_CREATED_USER_ID",
                table: "INCIDENT",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_INCIDENT_USER_UPDATED_USER_ID",
                table: "INCIDENT",
                column: "UPDATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INCIDENT_USER_CREATED_USER_ID",
                table: "INCIDENT");

            migrationBuilder.DropForeignKey(
                name: "FK_INCIDENT_USER_UPDATED_USER_ID",
                table: "INCIDENT");

            migrationBuilder.DropIndex(
                name: "IX_INCIDENT_CREATED_USER_ID",
                table: "INCIDENT");

            migrationBuilder.DropIndex(
                name: "IX_INCIDENT_UPDATED_USER_ID",
                table: "INCIDENT");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "INCIDENT");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "INCIDENT");
        }
    }
}
