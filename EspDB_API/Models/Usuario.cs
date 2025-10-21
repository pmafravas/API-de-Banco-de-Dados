namespace EspDB_API.Models;

public class Usuario
{
    private int IdUser { get; set; }
    private string Nome { get; set; }
    private string IdBluetooth { get; set; }
    private bool FlagPodeEntrar { get; set; }
    private bool FlagHoraControlada { get; set; }
    private ControleEntrada controleEntrada { get; set; }
    private RegistroEntrada registroEntrada { get; set; }
}