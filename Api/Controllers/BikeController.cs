using Application.Mappers;
using Domain.Enums;

namespace Api.Controllers;

[ApiController]
[Route("api/v1")]
public class BikeController : ControllerBase
{
    private readonly IBikeService _bikeService;

    public BikeController(IBikeService bikeService)
    {
        _bikeService = bikeService;
    }

    /// <summary>
    /// Gets paginated bikes filtered by category.
    /// </summary>
    [HttpGet]
    [Route("Bikes")]
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
    /// <param name="Id">The unique identifier of the bike.</param>
    /// <returns>The bike's information if found; otherwise, an error response.</returns>
    [HttpGet]
    [Route("Bike/{Id:Guid}")]
    [ProducesResponseType(typeof(BikeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetBike([FromRoute, Required] Guid Id)
    {
        try
        {
            var result = await _bikeService.GetBike(Id);
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

    /// <summary>
    /// Adds a new bike to the system.
    /// </summary>
    [HttpPost]
    [Route("Bike")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddBike([FromBody] BikeDto bike)
    {
        try
        {
            var result = await _bikeService.AddBike(BikeMapper.ToDomain(bike));
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

    /// <summary>
    /// Updates the information of an existing bike.
    /// </summary>
    [HttpPut]
    [Route("Bike")]
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

    /// <summary>
    /// Changes the state of a bike.
    /// </summary>
    [HttpPatch("{id:Guid}/State")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ChangeStatus([FromQuery, Required] Guid id, [FromQuery, Required] BikeState state)
    {
        try
        {
            var result = await _bikeService.ChangeStatus(id, state);
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

    /// <summary>
    /// Deletes a bike from the system.
    /// </summary>
    [HttpDelete]
    [Route("Bike")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteBike([FromQuery, Required] Guid id)
    {
        try
        {
            var result = await _bikeService.DeleteBike(id);
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
