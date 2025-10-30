using Application.Mappers;
using Domain.Enums;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]/")]
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
    [Route("/Bikes")]
    [ProducesResponseType(typeof(BikeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetBikes([FromQuery] int page = 1,
                                                 [FromQuery] int pageSize = 10,
                                                 [FromQuery] string? category = null)
    {
        try
        {
            var result = await _bikeService.GetPagedAsync(page, pageSize, category);
            return Ok(result);
        }
        catch (InfrastructureException ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "An error was detected while executing the service.Error:" + ex.Message);
        }
    }


    /// <summary>
    /// Retrieves a bike by its unique identifier.
    /// </summary>
    /// <param name="bikeId">The unique identifier of the bike.</param>
    /// <returns>The bike's information if found; otherwise, an error response.</returns>
    [HttpGet]
    [Route("v1/BikesById")]
    [ProducesResponseType(typeof(BikeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetBike([FromQuery, Required] Guid bikeId)
    {
        try
        {
            var result = await _bikeService.GetBike(bikeId);
            return Ok(result);
        }
        catch (InfrastructureException ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error was detected while executing the service.Error:" + ex.Message);
        }
    }


    [HttpPut("v1/{id}")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateBikeInfo([FromBody] BikeDto bike)
    {
        try
        {
            var result = await _bikeService.UpdateBikeInfo(BikeMapper.ToDomain(bike));
            return Ok(result);
        }
        catch (InfrastructureException ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error was detected while executing the service.Error:" + ex.Message);
        }
    }

    [HttpPatch("v1/{id}/State")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ChangeStatus([FromQuery, Required] Guid bikeId, [FromQuery, Required] BikeState state)
    {
        try
        {
            var result = await _bikeService.ChangeStatus(bikeId, state);
            return Ok(result);
        }
        catch (InfrastructureException ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error was detected while executing the service.Error:" + ex.Message);
        }
    }

}
