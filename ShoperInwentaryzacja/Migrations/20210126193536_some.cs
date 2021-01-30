using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoperInwentaryzacja.Migrations
{
    public partial class some : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Option",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "ShopID",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Inventory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Option",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShopID",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
