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

    [HttpGet]
    public async Task<IActionResult> GetAllBikes()
    {
        var bikes = await _bikeServices.GetAllBikes();
        return Ok(bikes);
    }

}
