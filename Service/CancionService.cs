using AutoMapper;
using segParAgustinSantinaqueApi.Dal;
using segParAgustinSantinaqueApi.Dto.Cancion;
using segParAgustinSantinaqueApi.Service.Interface;

namespace segParAgustinSantinaqueApi.Service;

public class CancionService: ICancionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CancionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<List<CancionGetDto>> BuscarCanciones(string? nombreCancion, string? banda, int? duracionCancion)
    {
        var canciones = await _unitOfWork.CancionRepository.BuscarCanciones(nombreCancion, banda, duracionCancion);
        return _mapper.Map<List<CancionGetDto>>(canciones);
    }
}