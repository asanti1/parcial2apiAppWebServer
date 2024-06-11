using segParAgustinSantinaqueApi.Dto.Disco;

namespace segParAgustinSantinaqueApi.Service.Interface;

public interface IDiscoService
{
    Task<List<DiscoGetDto>> GetTopCincoDiscos();
    Task<List<DiscoGetDto>> Buscar(string? genero, string? banda, int? cantidadVendida, string? tituloDisco);
    Task<DiscoGetDto> Actualizar(string sku, DiscoUpdateDto disco);
    Task<DiscoGetDto> Crear(DiscoPostDto nuevoDisco);
}