using segParAgustinSantinaqueApi.Dto.Cancion;

namespace segParAgustinSantinaqueApi.Dto.Disco;

public class DiscoPostDto
{
    public string Nombre { get; set; }
    public string Banda { get; set; }
    public DateTime FechaLanzamiento { get; set; }
    public string Genero { get; set; }
    public int UnidadesVendidas { get; set; }
    public string SKU { get; set; }
    public ICollection<CancionPostDto> Canciones { get; set; }
}