using segParAgustinSantinaqueApi.Dal.Data;
using segParAgustinSantinaqueApi.Dal.Repository.Interface;

namespace segParAgustinSantinaqueApi.Dal;

public class UnitOfWork : IUnitOfWork
{
    public ICancionRepository CancionRepository { get; }
    public IDiscoRepository DiscoRepository { get; } 
    public IUsuarioRepository UsuarioRepository { get; }

    private readonly DataContext _context;

    public UnitOfWork(DataContext context, ICancionRepository cancionRepository, IDiscoRepository discoRepository,
        IUsuarioRepository usuarioRepository)
    {
        _context = context;
        CancionRepository = cancionRepository;
        DiscoRepository = discoRepository;
        UsuarioRepository = usuarioRepository;
    }

    public async Task<int> Save()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}