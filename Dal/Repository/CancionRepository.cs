using Microsoft.EntityFrameworkCore;
using segParAgustinSantinaqueApi.Dal.Data;
using segParAgustinSantinaqueApi.Dal.Entities;
using segParAgustinSantinaqueApi.Dal.Repository.Interface;

namespace segParAgustinSantinaqueApi.Dal.Repository;

public class CancionRepository : Repository<Cancion>, ICancionRepository
{
    public CancionRepository(DataContext context) : base(context)
    {
    }

    public async Task<List<Cancion>> BuscarCanciones(string? nombreCancion, string? banda, int? duracionCancion)
    {
        var query = _context.Canciones.Include(c => c.Disco).AsQueryable();

        if (!string.IsNullOrEmpty(nombreCancion))
            query = query.Where(c => c.TituloCancion.Contains(nombreCancion));

        if (!string.IsNullOrEmpty(banda))
            query = query.Where(c => c.Disco.Banda.Contains(banda));
        
        if (duracionCancion.HasValue)
            query = query.Where(c => c.TiempoDuracion == duracionCancion);
        
        return await query.ToListAsync();
    }
}