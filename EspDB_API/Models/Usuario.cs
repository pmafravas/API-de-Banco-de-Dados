namespace EspDB_API.Models;

public class Usuario
{
    public int IdUser { get; set; }
    public string Nome { get; set; }
    public string IdBluetooth { get; set; }
    public bool FlagPodeEntrar { get; set; }
    public bool FlagHoraControlada { get; set; }
    public ControleEntrada controleEntrada { get; set; }
    public RegistroEntrada registroEntrada { get; set; }

    public Usuario(string idBluetooth, string nomeDispositivo)
    {
        Nome = "GenericUser_" + nomeDispositivo;
        IdBluetooth = idBluetooth;
    }
}