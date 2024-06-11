using segParAgustinSantinaqueApi.Dal.Entities;

namespace segParAgustinSantinaqueApi.Dal.Repository.Interface;

public interface ICancionRepository : IRepository<Cancion>
{
    Task<List<Cancion>> BuscarCanciones(string? nombreCancion, string? banda, int? duracionCancion);
}