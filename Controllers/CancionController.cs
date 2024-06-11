using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using segParAgustinSantinaqueApi.Dto.Cancion;
using segParAgustinSantinaqueApi.Service.Interface;

namespace segParAgustinSantinaqueApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CancionController : ControllerBase
{
    private readonly ILogger<CancionController> _logger;
    private readonly ICancionService _cancionService;

    public CancionController(ICancionService cancionService, ILogger<CancionController> logger)
    {
        _logger = logger;
        _cancionService = cancionService;
    }
    
    [AllowAnonymous]
    [HttpGet("BuscarCanciones")]
    public async Task<ActionResult<List<CancionGetDto>>> BuscarCanciones([FromQuery] string? nombreCancion, [FromQuery] string? banda, [FromQuery] int? duracionCancion)
    {
        var resultados = await _cancionService.BuscarCanciones(nombreCancion, banda, duracionCancion);
        if (resultados.Count == 0) return NoContent();
        return Ok(resultados);
    }

}