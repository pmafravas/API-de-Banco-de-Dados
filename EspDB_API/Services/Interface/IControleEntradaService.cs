namespace EspDB_API.Services.Interface;

public interface IControleEntradaService
{
    public Task<List<DateTime>> GetHorariosDeUser(int IdUser);
    public Task DefinirHorarioUser(int IdUser, DateTime HorarioInicial, DateTime HorarioFinal);
    public Task DefinirHorariosExtra(int  IdUser, DateTime HorarioInicial, DateTime HorarioFinal);
}