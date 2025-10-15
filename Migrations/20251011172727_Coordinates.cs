using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Coordinates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "KursyPrzystanki");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "KursyPrzystanki");

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Przystanki",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Przystanki",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Przystanki");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Przystanki");

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "KursyPrzystanki",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "KursyPrzystanki",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
