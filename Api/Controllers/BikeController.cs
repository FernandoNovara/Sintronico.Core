using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BikeController : ControllerBase
{
    private readonly BikeServices _bikeServices;

    public BikeController(BikeServices bikeServices)
    {
        _bikeServices = bikeServices;
    }

    /// <summary>
    /// Obtiene bicicletas paginadas con filtro por categoría.
    /// </summary>
    [HttpGet]
    [Route("api/v1/bikes")]
    public async Task<IActionResult> GetAllBikes([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? category = null)
    {
        try
        {
            var bikes = await _bikeServices.GetAllBikes(page, pageSize, category);
            return Ok(bikes);
        }
        catch (Exception ex)
        {
            
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

}
