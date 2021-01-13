using Microsoft.EntityFrameworkCore.Migrations;

namespace MES.DB.Migrations
{
    public partial class MES4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JsonData",
                table: "LOGGER_REQUEST",
                newName: "JSONDATA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JSONDATA",
                table: "LOGGER_REQUEST",
                newName: "JsonData");
        }
    }
}
