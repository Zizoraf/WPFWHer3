using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class AddinformationofDirectors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Regisseurs_DirectorId",
                table: "Films");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regisseurs",
                table: "Regisseurs");

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.RenameTable(
                name: "Regisseurs",
                newName: "Directors");

            migrationBuilder.AlterColumn<long>(
                name: "DirectorId",
                table: "Films",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directors",
                table: "Directors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Directors_DirectorId",
                table: "Films",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Directors_DirectorId",
                table: "Films");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Directors",
                table: "Directors");

            migrationBuilder.RenameTable(
                name: "Directors",
                newName: "Regisseurs");

            migrationBuilder.AlterColumn<long>(
                name: "DirectorId",
                table: "Films",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regisseurs",
                table: "Regisseurs",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "DirectorId", "Titel", "Year" },
                values: new object[,]
                {
                    { 1L, null, "The Shawshank Redemption", 1994 },
                    { 2L, null, "The Godfather", 1972 },
                    { 3L, null, "The Dark Knight", 2008 },
                    { 4L, null, "The Godfather Part II", 1974 },
                    { 5L, null, "12 Angry Men", 1957 },
                    { 6L, null, "Schindler's List", 1993 },
                    { 7L, null, "The Lord of the Rings: The Return of the King", 2003 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Regisseurs_DirectorId",
                table: "Films",
                column: "DirectorId",
                principalTable: "Regisseurs",
                principalColumn: "Id");
        }
    }
}
