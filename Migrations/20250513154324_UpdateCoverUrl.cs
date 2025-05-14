using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ksiegarnia.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCoverUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autorzy_Ksiazki_Autorzy_AuthorID",
                table: "Autorzy_Ksiazki");

            migrationBuilder.DropForeignKey(
                name: "FK_Autorzy_Ksiazki_Ksiazki_BookID",
                table: "Autorzy_Ksiazki");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Zamowienia_Ksiazki",
                table: "Zamowienia_Ksiazki");

            migrationBuilder.DropIndex(
                name: "IX_Zamowienia_Ksiazki_ID_Ksiazki",
                table: "Zamowienia_Ksiazki");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Zamowienia_Ksiazki");

            migrationBuilder.DropColumn(
                name: "BookPirce",
                table: "Autorzy_Ksiazki");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "Autorzy_Ksiazki",
                newName: "ID_Autora");

            migrationBuilder.RenameColumn(
                name: "BookID",
                table: "Autorzy_Ksiazki",
                newName: "ID_Ksiazki");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Autorzy_Ksiazki",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Autorzy_Ksiazki_AuthorID",
                table: "Autorzy_Ksiazki",
                newName: "IX_Autorzy_Ksiazki_ID_Autora");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zamowienia_Ksiazki",
                table: "Zamowienia_Ksiazki",
                columns: new[] { "ID_Ksiazki", "ID_Zamowienia" });

            migrationBuilder.AddForeignKey(
                name: "FK_Autorzy_Ksiazki_Autorzy_ID_Autora",
                table: "Autorzy_Ksiazki",
                column: "ID_Autora",
                principalTable: "Autorzy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Autorzy_Ksiazki_Ksiazki_ID_Ksiazki",
                table: "Autorzy_Ksiazki",
                column: "ID_Ksiazki",
                principalTable: "Ksiazki",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autorzy_Ksiazki_Autorzy_ID_Autora",
                table: "Autorzy_Ksiazki");

            migrationBuilder.DropForeignKey(
                name: "FK_Autorzy_Ksiazki_Ksiazki_ID_Ksiazki",
                table: "Autorzy_Ksiazki");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Zamowienia_Ksiazki",
                table: "Zamowienia_Ksiazki");

            migrationBuilder.RenameColumn(
                name: "ID_Autora",
                table: "Autorzy_Ksiazki",
                newName: "AuthorID");

            migrationBuilder.RenameColumn(
                name: "ID_Ksiazki",
                table: "Autorzy_Ksiazki",
                newName: "BookID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Autorzy_Ksiazki",
                newName: "Amount");

            migrationBuilder.RenameIndex(
                name: "IX_Autorzy_Ksiazki_ID_Autora",
                table: "Autorzy_Ksiazki",
                newName: "IX_Autorzy_Ksiazki_AuthorID");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Zamowienia_Ksiazki",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<decimal>(
                name: "BookPirce",
                table: "Autorzy_Ksiazki",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zamowienia_Ksiazki",
                table: "Zamowienia_Ksiazki",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_Ksiazki_ID_Ksiazki",
                table: "Zamowienia_Ksiazki",
                column: "ID_Ksiazki");

            migrationBuilder.AddForeignKey(
                name: "FK_Autorzy_Ksiazki_Autorzy_AuthorID",
                table: "Autorzy_Ksiazki",
                column: "AuthorID",
                principalTable: "Autorzy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Autorzy_Ksiazki_Ksiazki_BookID",
                table: "Autorzy_Ksiazki",
                column: "BookID",
                principalTable: "Ksiazki",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
