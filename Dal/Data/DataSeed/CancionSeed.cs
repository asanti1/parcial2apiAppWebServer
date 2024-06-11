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
            new() { Id = 3, DiscoId = 2, TituloCancion = "Wanna Be Startin' Somethin'", TiempoDuracion = 300 },
            new() { Id = 4, DiscoId = 2, TituloCancion = "Thriller", TiempoDuracion = 600 },
            new() { Id = 5, DiscoId = 3, TituloCancion = "Stairway to Heaven", TiempoDuracion = 760 },
            new() { Id = 6, DiscoId = 3, TituloCancion = "Black Dog", TiempoDuracion = 900 },
            new() { Id = 7, DiscoId = 4, TituloCancion = "Money", TiempoDuracion = 384 },
            new() { Id = 8, DiscoId = 4, TituloCancion = "Time", TiempoDuracion = 416 },
            new() { Id = 9, DiscoId = 5, TituloCancion = "Go Your Own Way", TiempoDuracion = 220 },
            new() { Id = 10, DiscoId = 5, TituloCancion = "Dreams", TiempoDuracion = 257 },
            new() { Id = 11, DiscoId = 6, TituloCancion = "Hotel California", TiempoDuracion = 391 },
            new() { Id = 12, DiscoId = 6, TituloCancion = "Life in the Fast Lane", TiempoDuracion = 286 },
            new() { Id = 13, DiscoId = 7, TituloCancion = "I Will Always Love You", TiempoDuracion = 273 },
            new() { Id = 14, DiscoId = 7, TituloCancion = "I'm Every Woman", TiempoDuracion = 275 },
            new() { Id = 15, DiscoId = 8, TituloCancion = "Stayin' Alive", TiempoDuracion = 283 },
            new() { Id = 16, DiscoId = 8, TituloCancion = "How Deep Is Your Love", TiempoDuracion = 240 },
            new() { Id = 17, DiscoId = 9, TituloCancion = "Come Together", TiempoDuracion = 259 },
            new() { Id = 18, DiscoId = 9, TituloCancion = "Something", TiempoDuracion = 182 },
            new() { Id = 19, DiscoId = 10, TituloCancion = "Rolling in the Deep", TiempoDuracion = 228 },
            new() { Id = 20, DiscoId = 10, TituloCancion = "Someone Like You", TiempoDuracion = 285 }
        );
    }
}