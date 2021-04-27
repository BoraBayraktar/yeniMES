using Microsoft.EntityFrameworkCore.Migrations;

namespace MES.DB.Migrations
{
    public partial class MES5_KnowledgeCreatedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "KNOWLEDGE_MANAGEMENT",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KNOWLEDGE_MANAGEMENT_CREATED_USER_ID",
                table: "KNOWLEDGE_MANAGEMENT",
                column: "CREATED_USER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_KNOWLEDGE_MANAGEMENT_USER_CREATED_USER_ID",
                table: "KNOWLEDGE_MANAGEMENT",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KNOWLEDGE_MANAGEMENT_USER_CREATED_USER_ID",
                table: "KNOWLEDGE_MANAGEMENT");

            migrationBuilder.DropIndex(
                name: "IX_KNOWLEDGE_MANAGEMENT_CREATED_USER_ID",
                table: "KNOWLEDGE_MANAGEMENT");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "KNOWLEDGE_MANAGEMENT");
        }
    }
}
