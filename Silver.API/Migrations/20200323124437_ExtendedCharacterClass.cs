using Microsoft.EntityFrameworkCore.Migrations;

namespace Silver.API.Migrations
{
    public partial class ExtendedCharacterClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FastAttAbility",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FastAttAbilityIcon",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialAttAbility",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialAttAbilityIcon",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialDefAbility",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialDefAbilityIcon",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StrongAttAbility",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StrongAttAbilityIcon",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StrongDefAbility",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StrongDefAbilityIcon",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fastDefAbility",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fastDefAbilityIcon",
                table: "Characters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FastAttAbility",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "FastAttAbilityIcon",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SpecialAttAbility",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SpecialAttAbilityIcon",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SpecialDefAbility",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SpecialDefAbilityIcon",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "StrongAttAbility",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "StrongAttAbilityIcon",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "StrongDefAbility",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "StrongDefAbilityIcon",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "fastDefAbility",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "fastDefAbilityIcon",
                table: "Characters");
        }
    }
}
