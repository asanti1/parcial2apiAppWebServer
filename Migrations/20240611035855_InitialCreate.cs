using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace segParAgustinSantinaqueApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    { 3, "Led Zeppelin", new DateTime(1971, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "Led Zeppelin IV", "GHI789", 37000000 }
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
                    { 6, 3, 900, "Black Dog" }
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
