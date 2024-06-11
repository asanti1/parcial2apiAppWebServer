using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using segParAgustinSantinaqueApi.Dto.Disco;
using segParAgustinSantinaqueApi.Service.Interface;

namespace segParAgustinSantinaqueApi.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class DiscoController : ControllerBase
{
    private readonly ILogger<DiscoController> _logger;
    private readonly IDiscoService _discoService;

    public DiscoController(IDiscoService discoService, ILogger<DiscoController> logger)
    {
        _logger = logger;
        _discoService = discoService;
    }
    
    [AllowAnonymous]
    [HttpGet("GetTopCinco")]
    public async Task<ActionResult<List<DiscoGetDto>>> GetTopCincoDiscos()
    {
        var result = await _discoService.GetTopCincoDiscos();
        if (result.Count == 0) return NoContent();
        return Ok(result);
    }
    
    [AllowAnonymous]
    [HttpGet("Buscar")]
    public async Task<ActionResult<List<DiscoGetDto>>> BuscarDiscos([FromQuery] string? genero,[FromQuery] string? banda,[FromQuery] int? cantidadVendida,[FromQuery] string? tituloDisco)
    {
        var discos = await _discoService.Buscar(genero, banda, cantidadVendida, tituloDisco);
        if (discos.Count == 0)
        {
            return NotFound();
        }
        return Ok(discos);
    }
    
    [HttpPut("ActualizarDisco/{sku}")]
    public async Task<ActionResult<DiscoGetDto>> ActualizarDisco([FromRoute] string sku, [FromBody] DiscoUpdateDto discoUpdate)
    {
        try
        {
            _logger.LogInformation("ActualizarDisco");
            var disco = await _discoService.Actualizar(sku,discoUpdate);
            if (disco != null) return Created(string.Empty,disco);

            return NotFound();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error en actualizar disco");
            return StatusCode(500, "Algo salio mal");
        }
    }

    [HttpPost("AgregarDisco")]
    public async Task<ActionResult<DiscoGetDto>> CrearDisco([FromBody] DiscoPostDto discoPost)
    {
        try
        {
            _logger.LogInformation("AgregarDisco");
            var disco = await _discoService.Crear(discoPost);
            return Created(string.Empty,disco);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error en agregar disco");
            return StatusCode(500, "Algo salio mal");
        }
    }
}