using EspDB_API.Repositories.Interface;
using EspDB_API.Services.Interface;

namespace EspDB_API.Services;

public class RegistroEntradaService : IRegistroEntradaService
{
    private readonly IRegistroEntradaRepository _registroEntradaRepository;

    public RegistroEntradaService(IRegistroEntradaRepository registroEntradaRepository)
    {
        _registroEntradaRepository = registroEntradaRepository;
    }
    public Task RegistrarEntrada(int IdUser, DateTime HoraAberto, DateTime HoraFechado)
    {
        return null;
    }
}