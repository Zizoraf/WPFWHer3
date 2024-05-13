using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class Addingsecondpartofmockinfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CreationDate", "Description", "FilmId", "Score", "Username" },
                values: new object[,]
                {
                    { 4L, new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Local), "Nice", 1L, 4, "PirateSoftware" },
                    { 5L, new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Local), "Noice", 1L, 5, "PirateSoftware" },
                    { 6L, new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Local), "Super noice", 1L, 3, "PirateSoftware" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6L);
        }
    }
}
