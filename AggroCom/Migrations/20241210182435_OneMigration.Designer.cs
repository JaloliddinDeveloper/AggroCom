﻿// <auto-generated />
using AggroCom.Brokers.Storages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AggroCom.Migrations
{
    [DbContext(typeof(StorageBroker))]
    [Migration("20241210182435_OneMigration")]
    partial class OneMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AggroCom.Models.Foundations.ProductOnes.ProductOne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KimyoviySinfi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreparatShakli")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductPicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductType")
                        .HasColumnType("int");

                    b.Property<string>("Qadogi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TasirModda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductOnes");
                });

            modelBuilder.Entity("AggroCom.Models.Foundations.ProductOnes.TableOne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BegonaQarshi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cheklovlar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EkinTuri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MavsumNechta")
                        .HasColumnType("int");

                    b.Property<int>("ProductOneId")
                        .HasColumnType("int");

                    b.Property<string>("SarfMeyori")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductOneId");

                    b.ToTable("TableOnes");
                });

            modelBuilder.Entity("AggroCom.Models.Foundations.ProductOnes.TableOne", b =>
                {
                    b.HasOne("AggroCom.Models.Foundations.ProductOnes.ProductOne", null)
                        .WithMany("TableOnes")
                        .HasForeignKey("ProductOneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AggroCom.Models.Foundations.ProductOnes.ProductOne", b =>
                {
                    b.Navigation("TableOnes");
                });
#pragma warning restore 612, 618
        }
    }
}