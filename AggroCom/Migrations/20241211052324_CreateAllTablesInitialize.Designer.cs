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
    [Migration("20241211052324_CreateAllTablesInitialize")]
    partial class CreateAllTablesInitialize
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("AggroCom.Models.Foundations.ProductOnes.ProductOne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("KimyoviySinfi")
                        .HasColumnType("longtext");

                    b.Property<string>("PreparatShakli")
                        .HasColumnType("longtext");

                    b.Property<string>("ProductPicture")
                        .HasColumnType("longtext");

                    b.Property<int>("ProductType")
                        .HasColumnType("int");

                    b.Property<string>("Qadogi")
                        .HasColumnType("longtext");

                    b.Property<string>("TasirModda")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ProductOnes");
                });

            modelBuilder.Entity("AggroCom.Models.Foundations.ProductOnes.TableOne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BegonaQarshi")
                        .HasColumnType("longtext");

                    b.Property<string>("Cheklovlar")
                        .HasColumnType("longtext");

                    b.Property<string>("EkinTuri")
                        .HasColumnType("longtext");

                    b.Property<int>("MavsumNechta")
                        .HasColumnType("int");

                    b.Property<int>("ProductOneId")
                        .HasColumnType("int");

                    b.Property<string>("SarfMeyori")
                        .HasColumnType("longtext");

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
