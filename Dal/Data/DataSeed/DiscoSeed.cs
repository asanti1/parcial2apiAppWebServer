using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using segParAgustinSantinaqueApi.Dal.Entities;

namespace segParAgustinSantinaqueApi.Dal.Data.DataSeed;

public class DiscoSeed : IEntityTypeConfiguration<Disco>
{
    public void Configure(EntityTypeBuilder<Disco> builder)
    {
        builder.HasData(
            new Disco
            {
                Id = 1,
                Nombre = "Back in Black",
                Banda = "AC/DC",
                FechaLanzamiento = new DateTime(1980, 7, 25),
                Genero = "Rock",
                UnidadesVendidas = 50000000,
                SKU = "ABC123"
            },
            new Disco
            {
                Id = 2,
                Nombre = "Thriller",
                Banda = "Michael Jackson",
                FechaLanzamiento = new DateTime(1982, 11, 30),
                Genero = "Pop",
                UnidadesVendidas = 66000000,
                SKU = "DEF456"
            },
            new Disco
            {
                Id = 3,
                Nombre = "Led Zeppelin IV",
                Banda = "Led Zeppelin",
                FechaLanzamiento = new DateTime(1971, 11, 8),
                Genero = "Rock",
                UnidadesVendidas = 37000000,
                SKU = "GHI789"
            },
            new Disco
            {
                Id = 4,
                Nombre = "The Dark Side of the Moon",
                Banda = "Pink Floyd",
                FechaLanzamiento = new DateTime(1973, 3, 1),
                Genero = "Rock",
                UnidadesVendidas = 45000000,
                SKU = "JKL012"
            },
            new Disco
            {
                Id = 5,
                Nombre = "Rumours",
                Banda = "Fleetwood Mac",
                FechaLanzamiento = new DateTime(1977, 2, 4),
                Genero = "Rock",
                UnidadesVendidas = 40000000,
                SKU = "MNO345"
            },
            new Disco
            {
                Id = 6,
                Nombre = "Hotel California",
                Banda = "Eagles",
                FechaLanzamiento = new DateTime(1976, 12, 8),
                Genero = "Rock",
                UnidadesVendidas = 42000000,
                SKU = "PQR678"
            },
            new Disco
            {
                Id = 7,
                Nombre = "The Bodyguard",
                Banda = "Whitney Houston",
                FechaLanzamiento = new DateTime(1992, 11, 17),
                Genero = "Soundtrack",
                UnidadesVendidas = 45000000,
                SKU = "STU901"
            },
            new Disco
            {
                Id = 8,
                Nombre = "Saturday Night Fever",
                Banda = "Bee Gees",
                FechaLanzamiento = new DateTime(1977, 11, 15),
                Genero = "Disco",
                UnidadesVendidas = 40000000,
                SKU = "VWX234"
            },
            new Disco
            {
                Id = 9,
                Nombre = "Abbey Road",
                Banda = "The Beatles",
                FechaLanzamiento = new DateTime(1969, 9, 26),
                Genero = "Rock",
                UnidadesVendidas = 31000000,
                SKU = "YZA567"
            },
            new Disco
            {
                Id = 10,
                Nombre = "21",
                Banda = "Adele",
                FechaLanzamiento = new DateTime(2011, 1, 24),
                Genero = "Pop",
                UnidadesVendidas = 31000000,
                SKU = "BCD890"
            }
        );
    }
}