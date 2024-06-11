using segParAgustinSantinaqueApi.Dal.Entities;
using segParAgustinSantinaqueApi.Dto.Disco;

namespace segParAgustinSantinaqueApi.Dal.Repository.Interface;

public interface IDiscoRepository : IRepository<Disco>
{
   Task<List<Disco>> GetTopCincoDiscos();
   Task<List<Disco>> Buscar(string? genero, string? banda, int? cantidadVendida, string? tituloDisco);
   Task<Disco> Actualizar(string sku, DiscoUpdateDto disco);
   Task<Disco> Crear(Disco disco);
}