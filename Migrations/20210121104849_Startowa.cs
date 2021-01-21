using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace biblioteka___nowy_projekt.Migrations
{
    public partial class Startowa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Czytelnik",
                columns: table => new
                {
                    Id_czytelnik = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imie = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    nazwisko = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    miasto = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    telefon = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Czytelni__930228A0C16893BC", x => x.Id_czytelnik);
                });

            migrationBuilder.CreateTable(
                name: "Kategoria",
                columns: table => new
                {
                    Id_kategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Kategori__AEFCAE468F7BD47F", x => x.Id_kategoria);
                });

            migrationBuilder.CreateTable(
                name: "Ksiazka",
                columns: table => new
                {
                    Id_Ksiazka = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tytul = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    autor = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    wydawnictwo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    rok_wydania = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    kategorie_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ksiazka__11D1C823156DC51E", x => x.Id_Ksiazka);
                    table.ForeignKey(
                        name: "FK_Ksiazka_ToKategorie",
                        column: x => x.kategorie_id,
                        principalTable: "Kategoria",
                        principalColumn: "Id_kategoria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienie",
                columns: table => new
                {
                    Id_zamowienie = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    czytelnik_id = table.Column<int>(nullable: true),
                    ksiazka_id = table.Column<int>(nullable: true),
                    data_zamowienia = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Zamowien__2E82864096D7305F", x => x.Id_zamowienie);
                    table.ForeignKey(
                        name: "FK_Zamowienie_ToCzytelnik",
                        column: x => x.czytelnik_id,
                        principalTable: "Czytelnik",
                        principalColumn: "Id_czytelnik",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zamowienie_ToKsiazka",
                        column: x => x.ksiazka_id,
                        principalTable: "Ksiazka",
                        principalColumn: "Id_Ksiazka",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ksiazka_kategorie_id",
                table: "Ksiazka",
                column: "kategorie_id");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_czytelnik_id",
                table: "Zamowienie",
                column: "czytelnik_id");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_ksiazka_id",
                table: "Zamowienie",
                column: "ksiazka_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zamowienie");

            migrationBuilder.DropTable(
                name: "Czytelnik");

            migrationBuilder.DropTable(
                name: "Ksiazka");

            migrationBuilder.DropTable(
                name: "Kategoria");
        }
    }
}
