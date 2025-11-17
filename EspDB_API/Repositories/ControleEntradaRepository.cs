using EspDB_API.Repositories.Interface;

namespace EspDB_API.Repositories;

public class ControleEntradaRepository : IControleEntradaRepository
{
    IConfiguration _configuration;

    public ControleEntradaRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
}