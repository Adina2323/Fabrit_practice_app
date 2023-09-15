﻿// <auto-generated />
using System;
using DataAcessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HeroesApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230913080922_FinalTouches")]
    partial class FinalTouches
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAcessLayer.Models.HeroItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int?>("Armour")
                        .HasColumnType("int");

                    b.Property<int?>("BasicDamage")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(500000000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Health")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("DataAcessLayer.Models.HeroItemPower", b =>
                {
                    b.Property<long>("HeroId")
                        .HasColumnType("bigint");

                    b.Property<long>("PowerId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.HasKey("HeroId", "PowerId");

                    b.HasIndex("PowerId");

                    b.ToTable("HeroItemPowers", (string)null);
                });

            modelBuilder.Entity("DataAcessLayer.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("HeroId")
                        .HasColumnType("bigint");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HeroId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("DataAcessLayer.Models.Power", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("PowerType")
                        .HasColumnType("int");

                    b.Property<string>("PowerTypeAsString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Powers");
                });

            modelBuilder.Entity("DataAcessLayer.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("HeroId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("LastActive")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Password")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("ProfilePictureId")
                        .HasColumnType("int");

                    b.Property<byte[]>("SaltPassword")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HeroId");

                    b.HasIndex("ProfilePictureId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataAcessLayer.Models.HeroItemPower", b =>
                {
                    b.HasOne("DataAcessLayer.Models.HeroItem", "Hero")
                        .WithMany("Powers")
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAcessLayer.Models.Power", "Power")
                        .WithMany("HeroPowers")
                        .HasForeignKey("PowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hero");

                    b.Navigation("Power");
                });

            modelBuilder.Entity("DataAcessLayer.Models.Image", b =>
                {
                    b.HasOne("DataAcessLayer.Models.HeroItem", "Hero")
                        .WithMany("Images")
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hero");
                });

            modelBuilder.Entity("DataAcessLayer.Models.User", b =>
                {
                    b.HasOne("DataAcessLayer.Models.HeroItem", "Hero")
                        .WithMany()
                        .HasForeignKey("HeroId");

                    b.HasOne("DataAcessLayer.Models.Image", "ProfilePicture")
                        .WithMany()
                        .HasForeignKey("ProfilePictureId");

                    b.Navigation("Hero");

                    b.Navigation("ProfilePicture");
                });

            modelBuilder.Entity("DataAcessLayer.Models.HeroItem", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Powers");
                });

            modelBuilder.Entity("DataAcessLayer.Models.Power", b =>
                {
                    b.Navigation("HeroPowers");
                });
#pragma warning restore 612, 618
        }
    }
}