using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ksiegarnia.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klienci_Adres_AddressID",
                table: "Klienci");

            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienia_Klienci_CustomerID",
                table: "Zamowienia");

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

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Zamowienia",
                newName: "ID_Klienta");

            migrationBuilder.RenameIndex(
                name: "IX_Zamowienia_CustomerID",
                table: "Zamowienia",
                newName: "IX_Zamowienia_ID_Klienta");

            migrationBuilder.RenameColumn(
                name: "numer_telefonu",
                table: "Klienci",
                newName: "telefon");

            migrationBuilder.RenameColumn(
                name: "AddressID",
                table: "Klienci",
                newName: "ID_Adresu");

            migrationBuilder.RenameIndex(
                name: "IX_Klienci_AddressID",
                table: "Klienci",
                newName: "IX_Klienci_ID_Adresu");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Adres",
                newName: "kod_pocztowy");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Adres",
                newName: "ulica");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Adres",
                newName: "miejscowosc");

            migrationBuilder.RenameColumn(
                name: "ApartmentNumber",
                table: "Adres",
                newName: "numer_mieszkania");

            migrationBuilder.AlterColumn<string>(
                name: "kod_pocztowy",
                table: "Adres",
                type: "character varying(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "numer_mieszkania",
                table: "Adres",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "numer_domu",
                table: "Adres",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Zamowienia_Ksiazki",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_Zamowienia = table.Column<int>(type: "integer", nullable: false),
                    ID_Ksiazki = table.Column<int>(type: "integer", nullable: false),
                    ilosc = table.Column<int>(type: "integer", nullable: false),
                    cena_ksiazki = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia_Ksiazki", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Zamowienia_Ksiazki_Ksiazki_ID_Ksiazki",
                        column: x => x.ID_Ksiazki,
                        principalTable: "Ksiazki",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienia_Ksiazki_Zamowienia_ID_Zamowienia",
                        column: x => x.ID_Zamowienia,
                        principalTable: "Zamowienia",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ksiazki",
                columns: new[] { "ID", "ID_Autora", "nazwa_obrazu", "opis", "gatunek", "jezyk", "ilosc_stron", "cena", "tytul" },
                values: new object[,]
                {
                    { 6, 41, "lalka.jpg", "Klasyczna powieść Bolesława Prusa.", "Powieść", "Polski", 640, 49.99m, "Lalka" },
                    { 7, 42, "1984.jpg", "Powieść George'a Orwella o totalitarnym państwie.", "Dystopia", "Angielski", 328, 39.99m, "1984" },
                    { 8, 43, "mistrz_malgorzata.jpg", "Rosyjska powieść Michaiła Bułhakowa.", "Powieść", "Rosyjski", 384, 55.00m, "Mistrz i Małgorzata" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_Ksiazki_ID_Ksiazki",
                table: "Zamowienia_Ksiazki",
                column: "ID_Ksiazki");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_Ksiazki_ID_Zamowienia",
                table: "Zamowienia_Ksiazki",
                column: "ID_Zamowienia");

            migrationBuilder.AddForeignKey(
                name: "FK_Klienci_Adres_ID_Adresu",
                table: "Klienci",
                column: "ID_Adresu",
                principalTable: "Adres",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienia_Klienci_ID_Klienta",
                table: "Zamowienia",
                column: "ID_Klienta",
                principalTable: "Klienci",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klienci_Adres_ID_Adresu",
                table: "Klienci");

            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienia_Klienci_ID_Klienta",
                table: "Zamowienia");

            migrationBuilder.DropTable(
                name: "Zamowienia_Ksiazki");

            migrationBuilder.DeleteData(
                table: "Ksiazki",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ksiazki",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ksiazki",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "numer_domu",
                table: "Adres");

            migrationBuilder.RenameColumn(
                name: "ID_Klienta",
                table: "Zamowienia",
                newName: "CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_Zamowienia_ID_Klienta",
                table: "Zamowienia",
                newName: "IX_Zamowienia_CustomerID");

            migrationBuilder.RenameColumn(
                name: "telefon",
                table: "Klienci",
                newName: "numer_telefonu");

            migrationBuilder.RenameColumn(
                name: "ID_Adresu",
                table: "Klienci",
                newName: "AddressID");

            migrationBuilder.RenameIndex(
                name: "IX_Klienci_ID_Adresu",
                table: "Klienci",
                newName: "IX_Klienci_AddressID");

            migrationBuilder.RenameColumn(
                name: "ulica",
                table: "Adres",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "numer_mieszkania",
                table: "Adres",
                newName: "ApartmentNumber");

            migrationBuilder.RenameColumn(
                name: "miejscowosc",
                table: "Adres",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "kod_pocztowy",
                table: "Adres",
                newName: "ZipCode");

            migrationBuilder.AlterColumn<string>(
                name: "ApartmentNumber",
                table: "Adres",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Adres",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(6)",
                oldMaxLength: 6);

            migrationBuilder.InsertData(
                table: "Ksiazki",
                columns: new[] { "ID", "ID_Autora", "nazwa_obrazu", "opis", "gatunek", "jezyk", "ilosc_stron", "cena", "tytul" },
                values: new object[,]
                {
                    { 3, 3, "harry_potter.jpg", "Pierwsza część serii o młodym czarodzieju.", "Fantasy", "Polski", 328, 45.50m, "Harry Potter i Kamień Filozoficzny" },
                    { 4, 4, "wiedzmin.jpg", "Pierwszy zbiór opowiadań o Wiedźminie Geralcie.", "Fantasy", "Polski", 288, 42.00m, "Ostatnie życzenie" },
                    { 5, 5, "gra_o_tron.jpg", "Pierwszy tom sagi 'Pieśni Lodu i Ognia'.", "Fantasy", "Polski", 512, 55.00m, "Gra o tron" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Klienci_Adres_AddressID",
                table: "Klienci",
                column: "AddressID",
                principalTable: "Adres",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienia_Klienci_CustomerID",
                table: "Zamowienia",
                column: "CustomerID",
                principalTable: "Klienci",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
