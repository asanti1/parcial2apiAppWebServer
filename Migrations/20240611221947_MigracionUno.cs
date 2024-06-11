using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace segParAgustinSantinaqueApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracionUno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Banda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaLanzamiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnidadesVendidas = table.Column<int>(type: "int", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Canciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TituloCancion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiempoDuracion = table.Column<int>(type: "int", nullable: false),
                    DiscoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Canciones_Discos_DiscoId",
                        column: x => x.DiscoId,
                        principalTable: "Discos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Discos",
                columns: new[] { "Id", "Banda", "FechaLanzamiento", "Genero", "Nombre", "SKU", "UnidadesVendidas" },
                values: new object[,]
                {
                    { 1, "AC/DC", new DateTime(1980, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "Back in Black", "ABC123", 50000000 },
                    { 2, "Michael Jackson", new DateTime(1982, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pop", "Thriller", "DEF456", 66000000 },
                    { 3, "Led Zeppelin", new DateTime(1971, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "Led Zeppelin IV", "GHI789", 37000000 },
                    { 4, "Pink Floyd", new DateTime(1973, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "The Dark Side of the Moon", "JKL012", 45000000 },
                    { 5, "Fleetwood Mac", new DateTime(1977, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "Rumours", "MNO345", 40000000 },
                    { 6, "Eagles", new DateTime(1976, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "Hotel California", "PQR678", 42000000 },
                    { 7, "Whitney Houston", new DateTime(1992, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Soundtrack", "The Bodyguard", "STU901", 45000000 },
                    { 8, "Bee Gees", new DateTime(1977, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Disco", "Saturday Night Fever", "VWX234", 40000000 },
                    { 9, "The Beatles", new DateTime(1969, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "Abbey Road", "YZA567", 31000000 },
                    { 10, "Adele", new DateTime(2011, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pop", "21", "BCD890", 31000000 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Name", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "john.doe@mail.com", "John", "123456", "johndoe" },
                    { 2, "carla.test@mail.com", "Carla", "2132435465", "carlatest" }
                });

            migrationBuilder.InsertData(
                table: "Canciones",
                columns: new[] { "Id", "DiscoId", "TiempoDuracion", "TituloCancion" },
                values: new object[,]
                {
                    { 1, 1, 360, "Hells Bells" },
                    { 2, 1, 250, "Shoot to Thrill" },
                    { 3, 2, 300, "Wanna Be Startin' Somethin'" },
                    { 4, 2, 600, "Thriller" },
                    { 5, 3, 760, "Stairway to Heaven" },
                    { 6, 3, 900, "Black Dog" },
                    { 7, 4, 384, "Money" },
                    { 8, 4, 416, "Time" },
                    { 9, 5, 220, "Go Your Own Way" },
                    { 10, 5, 257, "Dreams" },
                    { 11, 6, 391, "Hotel California" },
                    { 12, 6, 286, "Life in the Fast Lane" },
                    { 13, 7, 273, "I Will Always Love You" },
                    { 14, 7, 275, "I'm Every Woman" },
                    { 15, 8, 283, "Stayin' Alive" },
                    { 16, 8, 240, "How Deep Is Your Love" },
                    { 17, 9, 259, "Come Together" },
                    { 18, 9, 182, "Something" },
                    { 19, 10, 228, "Rolling in the Deep" },
                    { 20, 10, 285, "Someone Like You" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Canciones_DiscoId",
                table: "Canciones",
                column: "DiscoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Canciones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Discos");
        }
    }
}
