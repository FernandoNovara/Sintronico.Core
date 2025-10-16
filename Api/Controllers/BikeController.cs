using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BikeController : ControllerBase
{
    private readonly IBikeService _bikeService;

    public BikeController(IBikeService bikeService)
    {
        _bikeService = bikeService;
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
            var result = await _bikeService.GetPagedAsync(page, pageSize, category);
            return Ok(result);
        }
        catch (Exception ex)
        {

            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

}
