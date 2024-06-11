using Microsoft.EntityFrameworkCore;
using segParAgustinSantinaqueApi.Dal.Data;
using segParAgustinSantinaqueApi.Dal.Entities;
using segParAgustinSantinaqueApi.Dal.Repository.Interface;
using segParAgustinSantinaqueApi.Dto.Disco;

namespace segParAgustinSantinaqueApi.Dal.Repository;

public class DiscoRepository : Repository<Disco>, IDiscoRepository
{
    public DiscoRepository(DataContext context) : base(context)
    {
    }

    public async Task<List<Disco>> GetTopCincoDiscos()
    {
        var result = await _context.Discos
            .OrderByDescending(d => d.UnidadesVendidas)
            .Take(5)
            .ToListAsync();

        return result;
    }

    public async Task<List<Disco>> Buscar(string? genero, string? banda, int? cantidadVendida, string? tituloDisco)
    {
        var query = _context.Discos.AsQueryable();

        if (!string.IsNullOrEmpty(genero))
            query = query.Where(d => d.Genero.Contains(genero));

        if (!string.IsNullOrEmpty(banda))
            query = query.Where(d => d.Banda.Contains(banda));

        if (cantidadVendida.HasValue)
            query = query.Where(d => d.UnidadesVendidas == cantidadVendida);

        if (!string.IsNullOrEmpty(tituloDisco))
            query = query.Where(d => d.Nombre.Contains(tituloDisco));

        return await query.ToListAsync();
    }

    public async Task<Disco> Actualizar(string sku, DiscoUpdateDto disco)
    {
        var discoQuery = await _context.Discos.FirstOrDefaultAsync(d => d.SKU == sku);
        if (discoQuery == null) return null;

        if (disco.Nombre != null)
            discoQuery.Nombre = disco.Nombre;
        if (disco.Banda != null)
            discoQuery.Banda = disco.Banda;
        if (disco.Genero != null)
            discoQuery.Genero = disco.Genero;
        if (disco.CantidadVendida.HasValue)
            discoQuery.UnidadesVendidas = disco.CantidadVendida.Value;
        if (disco.FechaLanzamiento.HasValue)
            discoQuery.FechaLanzamiento = disco.FechaLanzamiento.Value;

        await _context.SaveChangesAsync();
        return await _context.Discos.FirstOrDefaultAsync(d => d.SKU == sku);
    }

    public async Task<Disco> Crear(Disco disco)
    {
        if (disco.Canciones != null)
        {
            foreach (var cancion in disco.Canciones)
            {
                cancion.Disco = disco;
            }
        }

        _context.Discos.Add(disco);
        await _context.SaveChangesAsync();

        return disco;
    }
}