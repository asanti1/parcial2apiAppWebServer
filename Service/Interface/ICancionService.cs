using segParAgustinSantinaqueApi.Dto.Cancion;

namespace segParAgustinSantinaqueApi.Service.Interface;

public interface ICancionService
{
    Task<List<CancionGetDto>> BuscarCanciones(string? nombreCancion, string? banda, int? duracionCancion);

}