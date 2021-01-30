using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoperInwentaryzacja.Migrations
{
    public partial class updat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InventoryID",
                table: "Inventories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InventoryID",
                table: "Inventories");
        }
    }
}
