using EspDB_API.Models;
namespace EspDB_API.Services.Interface;

public interface IUsuarioService
{
    public Task<Usuario> GetUserByBluetooth(string idBluetooth);
    public Task<Usuario> GetUserById(int idUser);
    public Task<bool> CreateBaseUser(string idBluetooth, string nomeDispositivo);
    public Task<IEnumerable<Usuario>> GetAllUsers();
}