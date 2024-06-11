using System.ComponentModel.DataAnnotations.Schema;

namespace segParAgustinSantinaqueApi.Dal.Entities;

public class Cancion : ClaseBase
{
    public string TituloCancion { get; set; }
    public int TiempoDuracion { get; set; }
    
    [ForeignKey(nameof(Disco))]
    public int DiscoId { get; set; }
    public Disco Disco { get; set; }
}