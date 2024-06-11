using segParAgustinSantinaqueApi.Dal.Entities;

namespace segParAgustinSantinaqueApi.Dal.Repository.Interface;

public interface IUsuarioRepository : IRepository<Usuario>
{
    public Task<Usuario> GetUser(string name);
}