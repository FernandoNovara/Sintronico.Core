namespace Api.Controllers;

[ApiController]
[Route("api/[controller]/v1/bikes")]
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
    [Route("/GetAllBikes")]
    public async Task<IActionResult> GetAllBikes([FromQuery] int page = 1,
                                                 [FromQuery] int pageSize = 10,
                                                 [FromQuery] string? category = null)
    {
        var result = await _bikeService.GetPagedAsync(page, pageSize, category);
        return Ok(result);
    }

}
