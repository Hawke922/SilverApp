using Microsoft.EntityFrameworkCore.Migrations;

namespace Silver.API.Migrations
{
    public partial class DungeonsCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dungeons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Difficulty = table.Column<int>(nullable: false),
                    DescriptionLong = table.Column<string>(nullable: true),
                    DescriptionShort = table.Column<string>(nullable: true),
                    BackgroundUrl = table.Column<string>(nullable: true),
                    ThumbnailUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dungeons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enemies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    PictureUrl = table.Column<string>(nullable: true),
                    ThumbnailUrl = table.Column<string>(nullable: true),
                    DescriptionLong = table.Column<string>(nullable: true),
                    DescriptionShort = table.Column<string>(nullable: true),
                    Hp = table.Column<int>(nullable: false),
                    FastAttack = table.Column<int>(nullable: false),
                    StrongAttack = table.Column<int>(nullable: false),
                    SpecialAttack = table.Column<int>(nullable: false),
                    FastDefense = table.Column<int>(nullable: false),
                    StrongDefense = table.Column<int>(nullable: false),
                    SpecialDefense = table.Column<int>(nullable: false),
                    FastAttAbility = table.Column<string>(nullable: true),
                    StrongAttAbility = table.Column<string>(nullable: true),
                    SpecialAttAbility = table.Column<string>(nullable: true),
                    fastDefAbility = table.Column<string>(nullable: true),
                    StrongDefAbility = table.Column<string>(nullable: true),
                    SpecialDefAbility = table.Column<string>(nullable: true),
                    FastAttAbilityIcon = table.Column<string>(nullable: true),
                    StrongAttAbilityIcon = table.Column<string>(nullable: true),
                    SpecialAttAbilityIcon = table.Column<string>(nullable: true),
                    fastDefAbilityIcon = table.Column<string>(nullable: true),
                    StrongDefAbilityIcon = table.Column<string>(nullable: true),
                    SpecialDefAbilityIcon = table.Column<string>(nullable: true),
                    IsBoss = table.Column<bool>(nullable: false),
                    DungeonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enemies_Dungeons_DungeonId",
                        column: x => x.DungeonId,
                        principalTable: "Dungeons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enemies_DungeonId",
                table: "Enemies",
                column: "DungeonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enemies");

            migrationBuilder.DropTable(
                name: "Dungeons");
        }
    }
}
