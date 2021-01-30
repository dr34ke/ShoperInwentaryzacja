using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoperInwentaryzacja.Migrations
{
    public partial class somee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InventoryID",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "ShopID",
                table: "Inventories");

            migrationBuilder.AddColumn<string>(
                name: "Option",
                table: "Inventories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Option",
                table: "Inventories");

            migrationBuilder.AddColumn<string>(
                name: "InventoryID",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShopID",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
