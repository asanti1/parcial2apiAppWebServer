using AutoMapper;
using segParAgustinSantinaqueApi.Dal.Entities;
using segParAgustinSantinaqueApi.Dto.Cancion;
using segParAgustinSantinaqueApi.Dto.Disco;

namespace segParAgustinSantinaqueApi;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Disco, DiscoGetDto>()
            .ForMember(x => x.TituloDisco, org => org.MapFrom(src => src.Nombre))
            .ForMember(x => x.Genero, org => org.MapFrom(src => src.Genero))
            .ForMember(x => x.Banda, org => org.MapFrom(src => src.Banda))
            .ForMember(x => x.CantidadVendida, org => org.MapFrom(src => src.UnidadesVendidas))
            .ForMember(x => x.CantidadCanciones, org => org.MapFrom(src => src.Canciones.Count))
            .ForMember(x => x.FechaLanzamiento, org => org.MapFrom(src => src.FechaLanzamiento.ToString("dd-MM-yyyy")));

        CreateMap<DiscoPostDto, Disco>();
        CreateMap<CancionPostDto, Cancion>();
        
        CreateMap<Cancion, CancionGetDto>()
            .ForMember(dest => dest.NombreCancion, opt => opt.MapFrom(src => src.TituloCancion))
            .ForMember(dest => dest.GeneroDelDisco, opt => opt.MapFrom(src => src.Disco.Genero))
            .ForMember(dest => dest.Banda, opt => opt.MapFrom(src => src.Disco.Banda))
            .ForMember(dest => dest.FechaLanzamientoDelDisco, opt => opt.MapFrom(src => src.Disco.FechaLanzamiento.ToString("dd-MM-yyyy")));
    }
    
}