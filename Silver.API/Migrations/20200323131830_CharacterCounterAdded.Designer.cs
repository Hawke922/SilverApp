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
    [Migration("20200323131830_CharacterCounterAdded")]
    partial class CharacterCounterAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("Silver.API.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CharacterCounter")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Class")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClassIcon")
                        .HasColumnType("TEXT");

                    b.Property<string>("FastAttAbility")
                        .HasColumnType("TEXT");

                    b.Property<string>("FastAttAbilityIcon")
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

                    b.Property<string>("SpecialAttAbility")
                        .HasColumnType("TEXT");

                    b.Property<string>("SpecialAttAbilityIcon")
                        .HasColumnType("TEXT");

                    b.Property<int>("SpecialAttack")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SpecialDefAbility")
                        .HasColumnType("TEXT");

                    b.Property<string>("SpecialDefAbilityIcon")
                        .HasColumnType("TEXT");

                    b.Property<int>("SpecialDefense")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StrongAttAbility")
                        .HasColumnType("TEXT");

                    b.Property<string>("StrongAttAbilityIcon")
                        .HasColumnType("TEXT");

                    b.Property<int>("StrongAttack")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StrongDefAbility")
                        .HasColumnType("TEXT");

                    b.Property<string>("StrongDefAbilityIcon")
                        .HasColumnType("TEXT");

                    b.Property<int>("StrongDefense")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("fastDefAbility")
                        .HasColumnType("TEXT");

                    b.Property<string>("fastDefAbilityIcon")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Silver.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
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

            modelBuilder.Entity("Silver.API.Models.Character", b =>
                {
                    b.HasOne("Silver.API.Models.User", "User")
                        .WithMany("Characters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
