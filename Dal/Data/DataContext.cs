using Microsoft.EntityFrameworkCore;
using segParAgustinSantinaqueApi.Dal.Data.DataSeed;
using segParAgustinSantinaqueApi.Dal.Entities;

namespace segParAgustinSantinaqueApi.Dal.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options){}
    public DbSet<Disco> Discos { get; set; }
    public DbSet<Cancion> Canciones { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DiscoSeed());
        modelBuilder.ApplyConfiguration(new CancionSeed());
        modelBuilder.ApplyConfiguration(new UsuarioSeed());
    }

}