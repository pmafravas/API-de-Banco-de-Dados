using EspDB_API.Models;
using EspDB_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EspDB_API.Controllers;

public class UsuarioController : ControllerBase
{
    readonly UsuarioService _usuarioService;
    readonly ILogger<UsuarioController> _logger;

    public UsuarioController(UsuarioService usuarioService, ILogger<UsuarioController> logger)
    {
        _usuarioService = usuarioService;
        _logger = logger;
    }
    
    [HttpGet("/api/usuario/get/bluetooth/{idBluetooth}")]
    public async Task<IActionResult> GetUserByBluetooth(string idBluetooth)
    {
        try
        {
            Usuario user = await _usuarioService.GetUserByBluetooth(idBluetooth);
            if (user == null)
            {
                _logger.LogInformation("Usuário requisitado não encontrado. ID'{idBluetooth}'", idBluetooth);
                return NotFound("Usuário não encontrado");
            }
            return Ok(user);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "ERRO. \nErro ao recuperar usuário por Bluetooth!");
            return StatusCode(500, "Houve um erro interno no servidor.");
        }
    }

    [HttpPost("/api/usuario/create/{idBluetooth}/{nomeAparelho}")]
    public async Task<IActionResult> CreateUser(string idBluetooth, string nomeAparelho)
    {
        try
        {
            if (string.IsNullOrEmpty(idBluetooth) || string.IsNullOrEmpty(nomeAparelho))
            {
                return BadRequest("Nem todos os dados foram providos");
            }
            
            bool user = await _usuarioService.CreateBaseUser(idBluetooth, nomeAparelho);
            if (user)
            {
                return Ok();
            }
            _logger.LogWarning("Usuário requisitado não criado. ID{'idBluetooth}'", idBluetooth);
            return Problem("Usuário não criado");

        }
        catch (Exception e)
        {
            _logger.LogError(e, "ERRO. \nErro ao criar novo usuário.");
            return StatusCode(500, "Houve um erro interno no servidor.");
        }
    }

    [HttpPost("/api/usuario/get")]
    public async Task<IActionResult> GetAllUsers()
    {
        try
        {
            List<Usuario> users = (await _usuarioService.GetAllUsers()).ToList();
            return Ok(users);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "ERRO. \nErro ao recuperar todos usuários.");
            return StatusCode(500, "Houve um erro interno no servidor.");
        }
    }
}