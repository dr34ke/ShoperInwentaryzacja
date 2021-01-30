using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoperInwentaryzacja.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "Inventory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ShopId",
                table: "Inventories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Inventories");
        }
    }
}
