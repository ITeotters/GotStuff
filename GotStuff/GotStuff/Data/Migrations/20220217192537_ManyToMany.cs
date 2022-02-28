using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GotStuff.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pantry_AspNetUsers_AppUserId1",
                table: "Pantry");

            migrationBuilder.DropIndex(
                name: "IX_Pantry_AppUserId1",
                table: "Pantry");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Pantry");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Pantry");

            migrationBuilder.CreateTable(
                name: "AppUserPantry",
                columns: table => new
                {
                    AppUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PantriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserPantry", x => new { x.AppUsersId, x.PantriesId });
                    table.ForeignKey(
                        name: "FK_AppUserPantry_AspNetUsers_AppUsersId",
                        column: x => x.AppUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserPantry_Pantry_PantriesId",
                        column: x => x.PantriesId,
                        principalTable: "Pantry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserPantry_PantriesId",
                table: "AppUserPantry",
                column: "PantriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserPantry");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Pantry",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
