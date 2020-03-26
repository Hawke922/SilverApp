using Microsoft.EntityFrameworkCore.Migrations;

namespace Silver.API.Migrations
{
    public partial class DungeonCodeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodeName",
                table: "Dungeons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeName",
                table: "Dungeons");
        }
    }
}
