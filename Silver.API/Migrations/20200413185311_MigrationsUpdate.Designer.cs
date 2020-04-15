﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Silver.API.Data;

namespace Silver.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200413185311_MigrationsUpdate")]
    partial class MigrationsUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("Silver.API.Models.Ability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BaseDamage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Icon")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsOffensive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("TypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("Silver.API.Models.AbilityCharacter", b =>
                {
                    b.Property<int>("AbilityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AbilityId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("AbilityCharacters");
                });

            modelBuilder.Entity("Silver.API.Models.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CodeName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("DungeonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExploreMax")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("ThumbnailUrl")
                        .HasColumnType("TEXT");

                    b.Property<int>("UnlockOn")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DungeonId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("Silver.API.Models.AreaProgress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AreaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Explored")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProgressId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProgressId");

                    b.ToTable("AreaProgress");
                });

            modelBuilder.Entity("Silver.API.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ActiveDungeonId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Class")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClassIcon")
                        .HasColumnType("TEXT");

                    b.Property<int>("FastAttack")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FastDefense")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Hp")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("TEXT");

                    b.Property<int>("SpecialAttack")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpecialDefense")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StrongAttack")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StrongDefense")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ThumbnailUrl")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Silver.API.Models.Dungeon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BackgroundUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("CodeName")
                        .HasColumnType("TEXT");

                    b.Property<string>("DescriptionLong")
                        .HasColumnType("TEXT");

                    b.Property<string>("DescriptionShort")
                        .HasColumnType("TEXT");

                    b.Property<int>("Difficulty")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("ThumbnailUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Dungeons");
                });

            modelBuilder.Entity("Silver.API.Models.DungeonProgress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DungeonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Explored")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProgressId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProgressId");

                    b.ToTable("DungeonProgress");
                });

            modelBuilder.Entity("Silver.API.Models.Enemy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AreaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("DungeonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FastAttack")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FastDefense")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Hp")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsBoss")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("TEXT");

                    b.Property<int>("SpecialAttack")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpecialDefense")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StrongAttack")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StrongDefense")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ThumbnailUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("DungeonId");

                    b.ToTable("Enemies");
                });

            modelBuilder.Entity("Silver.API.Models.EnemyAbility", b =>
                {
                    b.Property<int>("EnemyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AbilityId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EnemyId", "AbilityId");

                    b.HasIndex("AbilityId");

                    b.ToTable("EnemyAbilities");
                });

            modelBuilder.Entity("Silver.API.Models.Progress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("Progress");
                });

            modelBuilder.Entity("Silver.API.Models.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("Silver.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ActiveCharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Silver.API.Models.Ability", b =>
                {
                    b.HasOne("Silver.API.Models.Type", "Type")
                        .WithMany("Abilities")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Silver.API.Models.AbilityCharacter", b =>
                {
                    b.HasOne("Silver.API.Models.Ability", "Ability")
                        .WithMany("AbilityCharacters")
                        .HasForeignKey("AbilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Silver.API.Models.Character", "Character")
                        .WithMany("AbilityCharacters")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Silver.API.Models.Area", b =>
                {
                    b.HasOne("Silver.API.Models.Dungeon", "Dungeon")
                        .WithMany("Areas")
                        .HasForeignKey("DungeonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Silver.API.Models.AreaProgress", b =>
                {
                    b.HasOne("Silver.API.Models.Progress", "Progress")
                        .WithMany("AreaProgress")
                        .HasForeignKey("ProgressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Silver.API.Models.Character", b =>
                {
                    b.HasOne("Silver.API.Models.User", "User")
                        .WithMany("Characters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Silver.API.Models.DungeonProgress", b =>
                {
                    b.HasOne("Silver.API.Models.Progress", "Progress")
                        .WithMany("DungeonProgress")
                        .HasForeignKey("ProgressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Silver.API.Models.Enemy", b =>
                {
                    b.HasOne("Silver.API.Models.Area", null)
                        .WithMany("Enemies")
                        .HasForeignKey("AreaId");

                    b.HasOne("Silver.API.Models.Dungeon", "Dungeon")
                        .WithMany("Enemies")
                        .HasForeignKey("DungeonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Silver.API.Models.EnemyAbility", b =>
                {
                    b.HasOne("Silver.API.Models.Ability", "Ability")
                        .WithMany("EnemyAbilities")
                        .HasForeignKey("AbilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Silver.API.Models.Enemy", "Enemy")
                        .WithMany("EnemyAbilities")
                        .HasForeignKey("EnemyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Silver.API.Models.Progress", b =>
                {
                    b.HasOne("Silver.API.Models.Character", "Character")
                        .WithOne("Progress")
                        .HasForeignKey("Silver.API.Models.Progress", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}