using AutoMapper;
using segParAgustinSantinaqueApi.Dal;
using segParAgustinSantinaqueApi.Dal.Entities;
using segParAgustinSantinaqueApi.Dto.Disco;
using segParAgustinSantinaqueApi.Service.Interface;

namespace segParAgustinSantinaqueApi.Service;

public class DiscoService : IDiscoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DiscoService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<DiscoGetDto>> GetTopCincoDiscos()
    {
        var discos = await _unitOfWork.DiscoRepository.GetTopCincoDiscos();
        return _mapper.Map<List<DiscoGetDto>>(discos);
    }

    public async Task<List<DiscoGetDto>> Buscar(string? genero, string? banda, int? cantidadVendida, string? tituloDisco)
    {
        var discos = await _unitOfWork.DiscoRepository.Buscar(genero, banda, cantidadVendida, tituloDisco);
        return _mapper.Map<List<DiscoGetDto>>(discos);
    }

    public async Task<DiscoGetDto> Actualizar(string sku, DiscoUpdateDto disco)
    {
        var discoAct = await _unitOfWork.DiscoRepository.Actualizar(sku, disco);
        return _mapper.Map<DiscoGetDto>(discoAct);
    }

    public async Task<DiscoGetDto> Crear(DiscoPostDto nuevoDisco)
    {
        var disco = await _unitOfWork.DiscoRepository.Crear(_mapper.Map<Disco>(nuevoDisco));
        return _mapper.Map<DiscoGetDto>(disco);
    }
}