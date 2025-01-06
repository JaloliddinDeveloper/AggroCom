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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Katalogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Katalogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleUz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesUz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescribtionUz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescribtionRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameUz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductOnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleUz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesUz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionUz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TasirModdaUz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TasirModdaRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KimyoviySinfiUz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KimyoviySinfiRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreparatShakliUz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreparatShakliRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QadogiUz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QadogiRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductType = table.Column<int>(type: "int", nullable: false),
                    AdditionUz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionRu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOnes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTwos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleUz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameUz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesUz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionUZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SarfUz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SarfRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductTwoType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTwos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TableOnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EkinTuriUz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EkinTuriRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BegonaQarshiUz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BegonaQarshiRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SarfMeyoriUz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SarfMeyoriRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirgaSarfUz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirgaSarfRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Onlsum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductOneId = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameUz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foiz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductTwoId = table.Column<int>(type: "int", nullable: false)
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
