using EspDB_API.Models;
using EspDB_API.Repositories.Interface;
using EspDB_API.Services.Interface;
namespace EspDB_API.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }
    
    public async Task<Usuario> GetUserByBluetooth(string idBluetooth)
    {
        return await  _usuarioRepository.GetUserByBluetooth(idBluetooth);;
    }

    public async Task<Usuario> GetUserById(int idUser)
    {
        return await _usuarioRepository.GetUserById(idUser);
    }

    public async Task<bool> CreateBaseUser(string idBluetooth, string nomeDispositivo)
    {
        Usuario usuario = await GetUserByBluetooth(idBluetooth);
        if (!string.IsNullOrEmpty(usuario.IdBluetooth))
        {
            return false; //Barrado de criar 2 users com um único Bluetooth
        }

        return await _usuarioRepository.CreateBaseUser(idBluetooth, nomeDispositivo);
    }

    public Task<IEnumerable<Usuario>> GetAllUsers()
    {
        return _usuarioRepository.GetAllUsers();
    }

}