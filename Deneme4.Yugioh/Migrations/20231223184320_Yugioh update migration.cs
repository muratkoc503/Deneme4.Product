using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deneme4.Yugioh.Migrations
{
    public partial class Yugiohupdatemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Yugioh");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Yugioh",
                table: "Yugioh",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Yugioh",
                table: "Yugioh");

            migrationBuilder.RenameTable(
                name: "Yugioh",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");
        }
    }
}
