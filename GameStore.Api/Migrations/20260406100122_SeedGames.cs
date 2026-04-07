using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedGames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Genre", "Name", "Price", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, "Fighting", "Street Fighter II", 19.99m, new DateOnly(1992, 7, 15) },
                    { 2, "RPG", "Final Fantasy XIV", 59.99m, new DateOnly(2024, 2, 29) },
                    { 3, "Platformer", "Astro Bot", 59.99m, new DateOnly(2024, 9, 6) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
