using segParAgustinSantinaqueApi.Dal.Entities;

namespace segParAgustinSantinaqueApi.Service.Interface;

public interface ILoginService
{
    Task<Usuario> GetUser(string user, string pass);
}