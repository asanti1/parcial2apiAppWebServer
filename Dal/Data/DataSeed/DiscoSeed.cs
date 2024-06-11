using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using segParAgustinSantinaqueApi.Dal.Entities;

namespace segParAgustinSantinaqueApi.Dal.Data.DataSeed;

public class DiscoSeed : IEntityTypeConfiguration<Disco>
{
    public void Configure(EntityTypeBuilder<Disco> builder)
    {
        builder.HasData(new Disco {
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
            new Disco()
            {
                Id = 3,
                Nombre = "Led Zeppelin IV",
                Banda = "Led Zeppelin",
                FechaLanzamiento = new DateTime(1971, 11, 8),
                Genero = "Rock",
                UnidadesVendidas = 37000000,
                SKU = "GHI789"
            });
    }
}