using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ksiegarnia.Migrations
{
    /// <inheritdoc />
    public partial class SeedBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ksiazki",
                columns: new[] { "ID", "ID_Autora", "nazwa_obrazu", "opis", "gatunek", "jezyk", "ilosc_stron", "cena", "tytul" },
                values: new object[,]
                {
                    { 1, 1, "pan_tadeusz.jpg", "Najważniejsze dzieło polskiego romantyzmu.", "Epopeja", "Polski", 320, 39.99m, "Pan Tadeusz" },
                    { 2, 2, "to.jpg", "Przerażająca historia o kosmicznym złu w małym miasteczku.", "Horror", "Angielski", 512, 49.99m, "To" },
                    { 3, 3, "harry_potter.jpg", "Pierwsza część serii o młodym czarodzieju.", "Fantasy", "Polski", 328, 45.50m, "Harry Potter i Kamień Filozoficzny" },
                    { 4, 4, "wiedzmin.jpg", "Pierwszy zbiór opowiadań o Wiedźminie Geralcie.", "Fantasy", "Polski", 288, 42.00m, "Ostatnie życzenie" },
                    { 5, 5, "gra_o_tron.jpg", "Pierwszy tom sagi 'Pieśni Lodu i Ognia'.", "Fantasy", "Polski", 512, 55.00m, "Gra o tron" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ksiazki",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ksiazki",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ksiazki",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ksiazki",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ksiazki",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
