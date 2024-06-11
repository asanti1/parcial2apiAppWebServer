using Microsoft.EntityFrameworkCore;
using segParAgustinSantinaqueApi.Dal.Data;
using segParAgustinSantinaqueApi.Dal.Entities;
using segParAgustinSantinaqueApi.Dal.Repository.Interface;

namespace segParAgustinSantinaqueApi.Dal.Repository;

public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(DataContext context) : base(context)
    {
        
    }
    public async Task<Usuario> GetUser(string name)
    {
        return await _context.Usuarios.Where(x => x.UserName == name).FirstOrDefaultAsync();
    }
}