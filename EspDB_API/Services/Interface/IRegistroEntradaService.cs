using EspDB_API.Models;

namespace EspDB_API.Services.Interface;

public interface IRegistroEntradaService
{
    public Task RegistrarEntrada(int IdUser, DateTime HoraAberto, DateTime HoraFechado);
}