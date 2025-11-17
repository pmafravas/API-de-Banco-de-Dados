using System.Data;
using EspDB_API.Repositories.Interface;
using Dapper;
using EspDB_API.Models;
using MySqlConnector;

namespace EspDB_API.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    public UsuarioRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("DefaultConnection");
    }

    private IDbConnection CreateConnection()
    {
        return new MySqlConnection(_connectionString);
    }
    
    public async Task<Usuario> GetUserByBluetooth(string idBluetooth)
    {
        string query = @"SELECT * FROM Usuario WHERE IdBluetooth = @idBluetooth";

        using (IDbConnection BD = CreateConnection())
        {
            Usuario usuario = await BD.QueryFirstOrDefaultAsync(query, new { idBluetooth });
            if (usuario != null)
            {
                return usuario;
            }
        }
        return null;
    }

    public async Task<Usuario> GetUserById(int idUser)
    {
        string query = @"SELECT * FROM Usuario WHERE IdUser = @idUser";

        using (IDbConnection BD = CreateConnection())
        {
            Usuario usuario = await BD.QueryFirstOrDefaultAsync(query, new { idUser });
            if (usuario != null)
            {
                return usuario;
            }
        }
        return null;
    }

    public async Task<bool> CreateBaseUser(string idBluetooth, string nomeDispositivo)
    {
        string query = @"INSERT INTO Usuario (Nome, IdBluetooth)
                        VALUES (@Nome, @IdBluetooth)";
        Usuario usuario = new Usuario(idBluetooth, nomeDispositivo);

        using (IDbConnection BD = CreateConnection())
        {
            int linhasAfetadas  = await BD.ExecuteAsync(query);
            if (linhasAfetadas > 0)
                return true;
        }
        return false;
    }

    public async Task<IEnumerable<Usuario>> GetAllUsers()
    {
        string query = @"SELECT IdBluetooth, FlagPodeEntrar FROM Usuarios";
        
        using (IDbConnection BD = CreateConnection())
        {
            IEnumerable<Usuario> usuarios = await BD.QueryAsync<Usuario>(query);
            if(usuarios.Count() > 0)
                return usuarios;
        }
        return null;
    }   
}