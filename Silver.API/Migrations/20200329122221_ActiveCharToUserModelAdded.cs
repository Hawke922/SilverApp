using Microsoft.EntityFrameworkCore.Migrations;

namespace Silver.API.Migrations
{
    public partial class ActiveCharToUserModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActiveCharacterId",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveCharacterId",
                table: "Users");
        }
    }
}
