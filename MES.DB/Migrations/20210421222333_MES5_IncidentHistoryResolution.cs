using Microsoft.EntityFrameworkCore.Migrations;

namespace MES.DB.Migrations
{
    public partial class MES5_IncidentHistoryResolution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "INCIDENT_HISTORY",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "INCIDENT_HISTORY",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_HISTORY_CREATED_USER_ID",
                table: "INCIDENT_HISTORY",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_HISTORY_UPDATED_USER_ID",
                table: "INCIDENT_HISTORY",
                column: "UPDATED_USER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_INCIDENT_HISTORY_USER_CREATED_USER_ID",
                table: "INCIDENT_HISTORY",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_INCIDENT_HISTORY_USER_UPDATED_USER_ID",
                table: "INCIDENT_HISTORY",
                column: "UPDATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INCIDENT_HISTORY_USER_CREATED_USER_ID",
                table: "INCIDENT_HISTORY");

            migrationBuilder.DropForeignKey(
                name: "FK_INCIDENT_HISTORY_USER_UPDATED_USER_ID",
                table: "INCIDENT_HISTORY");

            migrationBuilder.DropIndex(
                name: "IX_INCIDENT_HISTORY_CREATED_USER_ID",
                table: "INCIDENT_HISTORY");

            migrationBuilder.DropIndex(
                name: "IX_INCIDENT_HISTORY_UPDATED_USER_ID",
                table: "INCIDENT_HISTORY");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "INCIDENT_HISTORY");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "INCIDENT_HISTORY");
        }
    }
}
