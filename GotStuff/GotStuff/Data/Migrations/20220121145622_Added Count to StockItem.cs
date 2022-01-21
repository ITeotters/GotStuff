using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GotStuff.Migrations
{
    public partial class AddedCounttoStockItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "StockItem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "StockItem");
        }
    }
}
