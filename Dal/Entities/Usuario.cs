namespace segParAgustinSantinaqueApi.Dal.Entities;

public class Usuario  : ClaseBase
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}