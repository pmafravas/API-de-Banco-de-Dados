using EspDB_API.Repositories.Interface;
using EspDB_API.Services.Interface;

namespace EspDB_API.Services;

public class ControleEntradaService : IControleEntradaService
{
    private readonly IControleEntradaRepository _controleEntradaRepository;

    public ControleEntradaService(IControleEntradaRepository controleEntradaRepository)
    {
        _controleEntradaRepository = controleEntradaRepository;
    }
    public Task<List<DateTime>> GetHorariosDeUser(int IdUser)
    {
        return null;
    }

    public Task DefinirHorarioUser(int IdUser, DateTime HorarioInicial, DateTime HorarioFinal)
    {
        return null;
    }

    public Task DefinirHorariosExtra(int IdUser, DateTime HorarioInicial, DateTime HorarioFinal)
    {
        return null;
    }

}