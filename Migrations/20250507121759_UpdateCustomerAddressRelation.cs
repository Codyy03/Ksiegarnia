using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ksiegarnia.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCustomerAddressRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    miejscowosc = table.Column<string>(type: "text", nullable: false),
                    ulica = table.Column<string>(type: "text", nullable: false),
                    numer_mieszkania = table.Column<string>(type: "text", nullable: false),
                    numer_domu = table.Column<string>(type: "text", nullable: false),
                    kod_pocztowy = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Autorzy",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    imie = table.Column<string>(type: "text", nullable: false),
                    nazwisko = table.Column<string>(type: "text", nullable: false),
                    narodowosc = table.Column<string>(type: "text", nullable: false),
                    biografia = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autorzy", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    imie = table.Column<string>(type: "text", nullable: false),
                    nazwisko = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    haslo = table.Column<string>(type: "text", nullable: false),
                    telefon = table.Column<string>(type: "text", nullable: false),
                    ID_Adresu = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienci", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Klienci_Adres_ID_Adresu",
                        column: x => x.ID_Adresu,
                        principalTable: "Adres",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Ksiazki",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tytul = table.Column<string>(type: "text", nullable: false),
                    gatunek = table.Column<string>(type: "text", nullable: false),
                    opis = table.Column<string>(type: "text", nullable: false),
                    cena = table.Column<decimal>(type: "numeric", nullable: false),
                    jezyk = table.Column<string>(type: "text", nullable: false),
                    ilosc_stron = table.Column<int>(type: "integer", nullable: false),
                    nazwa_obrazu = table.Column<string>(type: "text", nullable: false),
                    ID_Autora = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ksiazki", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ksiazki_Autorzy_ID_Autora",
                        column: x => x.ID_Autora,
                        principalTable: "Autorzy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienia",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    data_zamowienia = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    kwota = table.Column<decimal>(type: "numeric", nullable: false),
                    CustomerID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Zamowienia_Klienci_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Klienci",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Autorzy_Ksiazki",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "integer", nullable: false),
                    AuthorID = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    BookPirce = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autorzy_Ksiazki", x => new { x.BookID, x.AuthorID });
                    table.ForeignKey(
                        name: "FK_Autorzy_Ksiazki_Autorzy_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Autorzy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Autorzy_Ksiazki_Ksiazki_BookID",
                        column: x => x.BookID,
                        principalTable: "Ksiazki",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Autorzy_Ksiazki_AuthorID",
                table: "Autorzy_Ksiazki",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Klienci_ID_Adresu",
                table: "Klienci",
                column: "ID_Adresu");

            migrationBuilder.CreateIndex(
                name: "IX_Ksiazki_ID_Autora",
                table: "Ksiazki",
                column: "ID_Autora");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_CustomerID",
                table: "Zamowienia",
                column: "CustomerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autorzy_Ksiazki");

            migrationBuilder.DropTable(
                name: "Zamowienia");

            migrationBuilder.DropTable(
                name: "Ksiazki");

            migrationBuilder.DropTable(
                name: "Klienci");

            migrationBuilder.DropTable(
                name: "Autorzy");

            migrationBuilder.DropTable(
                name: "Adres");
        }
    }
}
