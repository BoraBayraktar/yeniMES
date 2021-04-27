﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MES.DB.Migrations
{
    public partial class MES7_KnowledgeUpdatedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "KNOWLEDGE_MANAGEMENT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "KNOWLEDGE_FILES",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "KNOWLEDGE_FILES",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KNOWLEDGE_MANAGEMENT_UPDATED_USER_ID",
                table: "KNOWLEDGE_MANAGEMENT",
                column: "UPDATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KNOWLEDGE_FILES_CREATED_USER_ID",
                table: "KNOWLEDGE_FILES",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KNOWLEDGE_FILES_UPDATED_USER_ID",
                table: "KNOWLEDGE_FILES",
                column: "UPDATED_USER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_KNOWLEDGE_FILES_USER_CREATED_USER_ID",
                table: "KNOWLEDGE_FILES",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KNOWLEDGE_FILES_USER_UPDATED_USER_ID",
                table: "KNOWLEDGE_FILES",
                column: "UPDATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KNOWLEDGE_MANAGEMENT_USER_UPDATED_USER_ID",
                table: "KNOWLEDGE_MANAGEMENT",
                column: "UPDATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KNOWLEDGE_FILES_USER_CREATED_USER_ID",
                table: "KNOWLEDGE_FILES");

            migrationBuilder.DropForeignKey(
                name: "FK_KNOWLEDGE_FILES_USER_UPDATED_USER_ID",
                table: "KNOWLEDGE_FILES");

            migrationBuilder.DropForeignKey(
                name: "FK_KNOWLEDGE_MANAGEMENT_USER_UPDATED_USER_ID",
                table: "KNOWLEDGE_MANAGEMENT");

            migrationBuilder.DropIndex(
                name: "IX_KNOWLEDGE_MANAGEMENT_UPDATED_USER_ID",
                table: "KNOWLEDGE_MANAGEMENT");

            migrationBuilder.DropIndex(
                name: "IX_KNOWLEDGE_FILES_CREATED_USER_ID",
                table: "KNOWLEDGE_FILES");

            migrationBuilder.DropIndex(
                name: "IX_KNOWLEDGE_FILES_UPDATED_USER_ID",
                table: "KNOWLEDGE_FILES");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "KNOWLEDGE_MANAGEMENT");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "KNOWLEDGE_FILES");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "KNOWLEDGE_FILES");
        }
    }
}
