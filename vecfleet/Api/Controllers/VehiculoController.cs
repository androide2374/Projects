using Api.Models;
using AutoMapper;
using Entities.Models;
using Framework.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiculoController : ControllerBase
{
    
    private readonly ILogger<VehiculoController> _logger;
    private readonly IVehiculoRepository _vehiculo;
    private readonly IMapper _mapper;

    public VehiculoController(ILogger<VehiculoController> logger, IVehiculoRepository vehiculo, IMapper mapper)
    {
        _logger = logger;
        _vehiculo = vehiculo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {

        var test = await _vehiculo.GetAllAsync();
        return Ok(test);
        }
        catch (Exception ex)
        {
            return StatusCode(500,ex);
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {

            
            return Ok(await _vehiculo.GetByIdAsync(id));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
    [HttpPost]
    public async Task<IActionResult> Post(VehiculoRequest request)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest();
            var vehiculo =_mapper.Map<Vehiculo>(request);
            await _vehiculo.AddAsync(vehiculo);
            return StatusCode(StatusCodes.Status201Created, vehiculo.Id);

        }
        catch (Exception ex)
        {
            return StatusCode(500,ex);
        }
    }
    [HttpPut]
    public async Task<IActionResult> Put([FromQuery] int id,[FromBody] VehiculoRequest request)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest();
            var vehiculo = _mapper.Map<Vehiculo>(request);
            vehiculo.Id = id;
            var result =await _vehiculo.UpdateAsync(vehiculo);
            if (!result) { return StatusCode(StatusCodes.Status204NoContent,"No se encontro vehiculo"); }
            return StatusCode(StatusCodes.Status200OK, vehiculo.Id);

        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
           var result= await _vehiculo.DeleteAsync(id);
            if (!result) return StatusCode(StatusCodes.Status400BadRequest, "No existe vehiculo para borrar");
            return Ok(id);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
}

