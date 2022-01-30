using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GotStuff.Data.Migrations
{
    public partial class ChangeTablesNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KnownProducts",
                table: "KnownProducts");

            migrationBuilder.RenameTable(
                name: "KnownProducts",
                newName: "KnownProduct");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KnownProduct",
                table: "KnownProduct",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "StockProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KnownProductId = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcquiredDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockProduct_KnownProduct_KnownProductId",
                        column: x => x.KnownProductId,
                        principalTable: "KnownProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockProduct_KnownProductId",
                table: "StockProduct",
                column: "KnownProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KnownProduct",
                table: "KnownProduct");

            migrationBuilder.RenameTable(
                name: "KnownProduct",
                newName: "KnownProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KnownProducts",
                table: "KnownProducts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KnownProductId = table.Column<int>(type: "int", nullable: false),
                    AcquiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_KnownProducts_KnownProductId",
                        column: x => x.KnownProductId,
                        principalTable: "KnownProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stock_KnownProductId",
                table: "Stock",
                column: "KnownProductId");
        }
    }
}
