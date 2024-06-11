using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using segParAgustinSantinaqueApi.Dal.Entities;

namespace segParAgustinSantinaqueApi.Dal.Data.DataSeed;

public class UsuarioSeed : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasData(new Usuario
                { Id = 1, Email = "john.doe@mail.com", Name = "John", UserName = "johndoe", Password = "123456" },
            new Usuario
            {
                Id = 2, Email = "carla.test@mail.com", Name = "Carla", UserName = "carlatest", Password = "2132435465"
            });
    }
}