using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GotStuff.Migrations
{
    public partial class RemovePantry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Pantry_PantryId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PantryId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PantryId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Pantry",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pantry_AppUserId1",
                table: "Pantry",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Pantry_AspNetUsers_AppUserId1",
                table: "Pantry",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pantry_AspNetUsers_AppUserId1",
                table: "Pantry");

            migrationBuilder.DropIndex(
                name: "IX_Pantry_AppUserId1",
                table: "Pantry");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Pantry");

            migrationBuilder.AddColumn<int>(
                name: "PantryId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PantryId",
                table: "AspNetUsers",
                column: "PantryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Pantry_PantryId",
                table: "AspNetUsers",
                column: "PantryId",
                principalTable: "Pantry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
