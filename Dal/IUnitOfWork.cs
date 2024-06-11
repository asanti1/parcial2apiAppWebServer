using segParAgustinSantinaqueApi.Dal.Repository.Interface;

namespace segParAgustinSantinaqueApi.Dal;

public interface IUnitOfWork : IDisposable
{
    IDiscoRepository DiscoRepository { get; } 
    ICancionRepository CancionRepository { get; }
    IUsuarioRepository UsuarioRepository { get; }
    Task<int> Save();
}