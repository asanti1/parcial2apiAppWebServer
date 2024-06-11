using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using segParAgustinSantinaqueApi.Dal.Entities;

namespace segParAgustinSantinaqueApi.Dal.Data.DataSeed;

public class CancionSeed: IEntityTypeConfiguration<Cancion>
{
    public void Configure(EntityTypeBuilder<Cancion> builder)
    {
        builder.HasData(
            new() { Id = 1, DiscoId = 1, TituloCancion = "Hells Bells", TiempoDuracion = 360 },
            new() { Id = 2, DiscoId = 1, TituloCancion = "Shoot to Thrill", TiempoDuracion = 250 },
            new() { Id = 3, DiscoId = 2, TituloCancion = "Wanna Be Startin' Somethin'",TiempoDuracion = 300},
            new() { Id = 4, DiscoId = 2, TituloCancion = "Thriller", TiempoDuracion = 600 },
            new() { Id = 5, DiscoId = 3, TituloCancion = "Stairway to Heaven", TiempoDuracion = 760 },
            new() { Id = 6, DiscoId = 3, TituloCancion = "Black Dog", TiempoDuracion = 900 }
        );

    }
}