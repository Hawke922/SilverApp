using Microsoft.EntityFrameworkCore.Migrations;

namespace Silver.API.Migrations
{
    public partial class ExploraionUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExploreMax",
                table: "Dungeons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnlockOn",
                table: "Dungeons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DungeonId",
                table: "AreaProgress",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExploreMax",
                table: "Dungeons");

            migrationBuilder.DropColumn(
                name: "UnlockOn",
                table: "Dungeons");

            migrationBuilder.DropColumn(
                name: "DungeonId",
                table: "AreaProgress");
        }
    }
}
