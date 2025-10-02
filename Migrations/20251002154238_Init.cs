using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Przystanki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Przystanki", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trasy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaLinii = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trasy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kursy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrasaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kursy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kursy_Trasy_TrasaId",
                        column: x => x.TrasaId,
                        principalTable: "Trasy",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KursyPrzystanki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KursId = table.Column<int>(type: "int", nullable: true),
                    PrzystanekId = table.Column<int>(type: "int", nullable: true),
                    Godzina = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KursyPrzystanki", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KursyPrzystanki_Kursy_KursId",
                        column: x => x.KursId,
                        principalTable: "Kursy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KursyPrzystanki_Przystanki_PrzystanekId",
                        column: x => x.PrzystanekId,
                        principalTable: "Przystanki",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kursy_TrasaId",
                table: "Kursy",
                column: "TrasaId");

            migrationBuilder.CreateIndex(
                name: "IX_KursyPrzystanki_KursId",
                table: "KursyPrzystanki",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_KursyPrzystanki_PrzystanekId",
                table: "KursyPrzystanki",
                column: "PrzystanekId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KursyPrzystanki");

            migrationBuilder.DropTable(
                name: "Kursy");

            migrationBuilder.DropTable(
                name: "Przystanki");

            migrationBuilder.DropTable(
                name: "Trasy");
        }
    }
}
