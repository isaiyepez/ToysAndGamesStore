using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToysAndGamesAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AgeRestriction", "Company", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 0, "Mattel", "Popular Board Game", "Monopoly", 70m },
                    { 2, 5, "Mattel", "Action Figure with sounds and light", "Iron Man Action Figure", 80m },
                    { 3, 8, "Mattel", "Beautiful and creepy doll at once", "Monster High doll", 30m },
                    { 4, 5, "Hasbro", "Dark Knight's most famous gadget!", "Batmobile", 180m },
                    { 5, 4, "Sony", "Sony famous console", "Playstation 5", 400m },
                    { 6, 18, "Naughty Dog", "Great Videogame from Naughty Dog!", "The last of Us 2", 60m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
