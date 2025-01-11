using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AggroCom.Migrations
{
    /// <inheritdoc />
    public partial class CreateAllTablesInitialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Message = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Katalogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileName = table.Column<string>(type: "TEXT", nullable: true),
                    FilePicture = table.Column<string>(type: "TEXT", nullable: true),
                    FilePath = table.Column<string>(type: "TEXT", nullable: true),
                    FileSize = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Katalogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TitleUz = table.Column<string>(type: "TEXT", nullable: true),
                    TitleRu = table.Column<string>(type: "TEXT", nullable: true),
                    DesUz = table.Column<string>(type: "TEXT", nullable: true),
                    DesRu = table.Column<string>(type: "TEXT", nullable: true),
                    DescribtionUz = table.Column<string>(type: "TEXT", nullable: true),
                    DescribtionRu = table.Column<string>(type: "TEXT", nullable: true),
                    NewPicture = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameUz = table.Column<string>(type: "TEXT", nullable: true),
                    NameRu = table.Column<string>(type: "TEXT", nullable: true),
                    PictureUrl = table.Column<string>(type: "TEXT", nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductOnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TitleUz = table.Column<string>(type: "TEXT", nullable: true),
                    TitleRu = table.Column<string>(type: "TEXT", nullable: true),
                    DesUz = table.Column<string>(type: "TEXT", nullable: true),
                    DesRu = table.Column<string>(type: "TEXT", nullable: true),
                    DescriptionUz = table.Column<string>(type: "TEXT", nullable: true),
                    DescriptionRu = table.Column<string>(type: "TEXT", nullable: true),
                    TasirModdaUz = table.Column<string>(type: "TEXT", nullable: true),
                    TasirModdaRu = table.Column<string>(type: "TEXT", nullable: true),
                    KimyoviySinfiUz = table.Column<string>(type: "TEXT", nullable: true),
                    KimyoviySinfiRu = table.Column<string>(type: "TEXT", nullable: true),
                    PreparatShakliUz = table.Column<string>(type: "TEXT", nullable: true),
                    PreparatShakliRu = table.Column<string>(type: "TEXT", nullable: true),
                    QadogiUz = table.Column<string>(type: "TEXT", nullable: true),
                    QadogiRu = table.Column<string>(type: "TEXT", nullable: true),
                    IconUrl = table.Column<string>(type: "TEXT", nullable: true),
                    ProductPicture = table.Column<string>(type: "TEXT", nullable: true),
                    ProductType = table.Column<int>(type: "INTEGER", nullable: false),
                    AdditionUz = table.Column<string>(type: "TEXT", nullable: true),
                    AdditionRu = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOnes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTwos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TitleUz = table.Column<string>(type: "TEXT", nullable: true),
                    TitleRu = table.Column<string>(type: "TEXT", nullable: true),
                    NameUz = table.Column<string>(type: "TEXT", nullable: true),
                    NameRu = table.Column<string>(type: "TEXT", nullable: true),
                    DesUz = table.Column<string>(type: "TEXT", nullable: true),
                    DesRu = table.Column<string>(type: "TEXT", nullable: true),
                    DescriptionUZ = table.Column<string>(type: "TEXT", nullable: true),
                    DescriptionRu = table.Column<string>(type: "TEXT", nullable: true),
                    SarfUz = table.Column<string>(type: "TEXT", nullable: true),
                    SarfRu = table.Column<string>(type: "TEXT", nullable: true),
                    ProductPicture = table.Column<string>(type: "TEXT", nullable: true),
                    ProductIcon = table.Column<string>(type: "TEXT", nullable: true),
                    ProductTwoType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTwos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TableOnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EkinTuriUz = table.Column<string>(type: "TEXT", nullable: true),
                    EkinTuriRu = table.Column<string>(type: "TEXT", nullable: true),
                    BegonaQarshiUz = table.Column<string>(type: "TEXT", nullable: true),
                    BegonaQarshiRu = table.Column<string>(type: "TEXT", nullable: true),
                    SarfMeyoriUz = table.Column<string>(type: "TEXT", nullable: true),
                    SarfMeyoriRu = table.Column<string>(type: "TEXT", nullable: true),
                    BirgaSarfUz = table.Column<string>(type: "TEXT", nullable: true),
                    BirgaSarfRu = table.Column<string>(type: "TEXT", nullable: true),
                    Onlsum = table.Column<string>(type: "TEXT", nullable: true),
                    ProductOneId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableOnes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableOnes_ProductOnes_ProductOneId",
                        column: x => x.ProductOneId,
                        principalTable: "ProductOnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableTwos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameUz = table.Column<string>(type: "TEXT", nullable: true),
                    NameRu = table.Column<string>(type: "TEXT", nullable: true),
                    Foiz = table.Column<string>(type: "TEXT", nullable: true),
                    ProductTwoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableTwos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableTwos_ProductTwos_ProductTwoId",
                        column: x => x.ProductTwoId,
                        principalTable: "ProductTwos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TableOnes_ProductOneId",
                table: "TableOnes",
                column: "ProductOneId");

            migrationBuilder.CreateIndex(
                name: "IX_TableTwos_ProductTwoId",
                table: "TableTwos",
                column: "ProductTwoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Katalogs");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "TableOnes");

            migrationBuilder.DropTable(
                name: "TableTwos");

            migrationBuilder.DropTable(
                name: "ProductOnes");

            migrationBuilder.DropTable(
                name: "ProductTwos");
        }
    }
}
