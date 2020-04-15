using Microsoft.EntityFrameworkCore.Migrations;

namespace Silver.API.Migrations
{
    public partial class MigrationsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActiveCharacterId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActiveDungeonId",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ClassIcon",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailUrl",
                table: "Characters",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dungeons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    CodeName = table.Column<string>(nullable: true),
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
                name: "Progress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Progress_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    CodeName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ThumbnailUrl = table.Column<string>(nullable: true),
                    UnlockOn = table.Column<int>(nullable: false),
                    ExploreMax = table.Column<int>(nullable: false),
                    DungeonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_Dungeons_DungeonId",
                        column: x => x.DungeonId,
                        principalTable: "Dungeons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AreaProgress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AreaId = table.Column<int>(nullable: false),
                    Explored = table.Column<int>(nullable: false),
                    ProgressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreaProgress_Progress_ProgressId",
                        column: x => x.ProgressId,
                        principalTable: "Progress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DungeonProgress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DungeonId = table.Column<int>(nullable: false),
                    Explored = table.Column<int>(nullable: false),
                    ProgressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DungeonProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DungeonProgress_Progress_ProgressId",
                        column: x => x.ProgressId,
                        principalTable: "Progress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BaseDamage = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    IsOffensive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abilities_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Description = table.Column<string>(nullable: true),
                    Hp = table.Column<int>(nullable: false),
                    FastAttack = table.Column<int>(nullable: false),
                    StrongAttack = table.Column<int>(nullable: false),
                    SpecialAttack = table.Column<int>(nullable: false),
                    FastDefense = table.Column<int>(nullable: false),
                    StrongDefense = table.Column<int>(nullable: false),
                    SpecialDefense = table.Column<int>(nullable: false),
                    IsBoss = table.Column<bool>(nullable: false),
                    DungeonId = table.Column<int>(nullable: false),
                    AreaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enemies_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enemies_Dungeons_DungeonId",
                        column: x => x.DungeonId,
                        principalTable: "Dungeons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbilityCharacters",
                columns: table => new
                {
                    AbilityId = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityCharacters", x => new { x.AbilityId, x.CharacterId });
                    table.ForeignKey(
                        name: "FK_AbilityCharacters_Abilities_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbilityCharacters_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnemyAbilities",
                columns: table => new
                {
                    EnemyId = table.Column<int>(nullable: false),
                    AbilityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnemyAbilities", x => new { x.EnemyId, x.AbilityId });
                    table.ForeignKey(
                        name: "FK_EnemyAbilities_Abilities_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnemyAbilities_Enemies_EnemyId",
                        column: x => x.EnemyId,
                        principalTable: "Enemies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_TypeId",
                table: "Abilities",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AbilityCharacters_CharacterId",
                table: "AbilityCharacters",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaProgress_ProgressId",
                table: "AreaProgress",
                column: "ProgressId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_DungeonId",
                table: "Areas",
                column: "DungeonId");

            migrationBuilder.CreateIndex(
                name: "IX_DungeonProgress_ProgressId",
                table: "DungeonProgress",
                column: "ProgressId");

            migrationBuilder.CreateIndex(
                name: "IX_Enemies_AreaId",
                table: "Enemies",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Enemies_DungeonId",
                table: "Enemies",
                column: "DungeonId");

            migrationBuilder.CreateIndex(
                name: "IX_EnemyAbilities_AbilityId",
                table: "EnemyAbilities",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Progress_CharacterId",
                table: "Progress",
                column: "CharacterId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbilityCharacters");

            migrationBuilder.DropTable(
                name: "AreaProgress");

            migrationBuilder.DropTable(
                name: "DungeonProgress");

            migrationBuilder.DropTable(
                name: "EnemyAbilities");

            migrationBuilder.DropTable(
                name: "Progress");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Enemies");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Dungeons");

            migrationBuilder.DropColumn(
                name: "ActiveCharacterId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ActiveDungeonId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "ClassIcon",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "ThumbnailUrl",
                table: "Characters");
        }
    }
}
