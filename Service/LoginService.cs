using segParAgustinSantinaqueApi.Dal;
using segParAgustinSantinaqueApi.Dal.Entities;
using segParAgustinSantinaqueApi.Service.Interface;

namespace segParAgustinSantinaqueApi.Service;

public class LoginService : ILoginService
{
    private readonly IUnitOfWork _unitOfWork;

    public LoginService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Usuario> GetUser(string user, string pass)
    {
        var usuarioEncontrado = await _unitOfWork.UsuarioRepository.GetUser(user);
        if (usuarioEncontrado == null)
        {
            return null;
        }
        return usuarioEncontrado.Password == pass ? usuarioEncontrado : null;
    }
}