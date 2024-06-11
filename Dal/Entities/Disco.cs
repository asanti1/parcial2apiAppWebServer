namespace segParAgustinSantinaqueApi.Dal.Entities;

public class Disco : ClaseBase
{
    public string Nombre { get; set; }
    public string Banda { get; set; }
    public DateTime FechaLanzamiento { get; set; }
    public string Genero { get; set; }
    public int UnidadesVendidas { get; set; }
    public string SKU { get; set; }
    public ICollection<Cancion> Canciones { get; set; }
}