using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class FillDirectorwithinfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Regisseurs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Frank Darabont" },
                    { 2L, "Francis Ford Coppola" },
                    { 3L, "Christopher Nolan" },
                    { 5L, "Sidney Lumet" },
                    { 6L, "Steven Spielberg" },
                    { 7L, "Peter Jackson" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regisseurs",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Regisseurs",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Regisseurs",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Regisseurs",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Regisseurs",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Regisseurs",
                keyColumn: "Id",
                keyValue: 7L);
        }
    }
}
