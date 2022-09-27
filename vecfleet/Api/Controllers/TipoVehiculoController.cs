using Api.Models;
using AutoMapper;
using Entities.Models;
using Framework.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TipoVehiculoController : ControllerBase
{

    private readonly ILogger<TipoVehiculoController> _logger;
    private readonly ITipoVehiculoRepository _tipoVehiculo;

    public TipoVehiculoController(ILogger<TipoVehiculoController> logger, ITipoVehiculoRepository tipoVehiculo)
    {
        _logger = logger;
        _tipoVehiculo = tipoVehiculo;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            return Ok(await _tipoVehiculo.GetAllAsync());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
}

