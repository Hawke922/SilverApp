using Microsoft.EntityFrameworkCore.Migrations;

namespace Silver.API.Migrations
{
    public partial class CharacterCounterAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharacterCounter",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ClassIcon",
                table: "Characters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharacterCounter",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "ClassIcon",
                table: "Characters");
        }
    }
}
