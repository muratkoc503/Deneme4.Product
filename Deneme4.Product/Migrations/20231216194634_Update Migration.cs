using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deneme4.Product.Migrations
{
    public partial class UpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "QuantityInStock",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "QuantityInStock",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
