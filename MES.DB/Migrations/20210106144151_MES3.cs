using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MES.DB.Migrations
{
    public partial class MES3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LOGGER_REQUEST",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONTROLLER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PATH = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    METHOD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JsonData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOGGER_REQUEST", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LOGGER_RESPONSE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REQUEST_ID = table.Column<int>(type: "int", nullable: false),
                    CONTROLLER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PATH = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    METHOD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JSONDATA = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOGGER_RESPONSE", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LOGGER_REQUEST");

            migrationBuilder.DropTable(
                name: "LOGGER_RESPONSE");
        }
    }
}
