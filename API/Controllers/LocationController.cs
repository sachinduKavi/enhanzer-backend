using Enhanzer.Core.Dtos.Location;
using Microsoft.AspNetCore.Mvc;
using HttpResponse = Enhanzer.Core.Dtos.Response.HttpResponse;

namespace Enhanzer.API.Controllers;


[ApiController]
[Route("[controller]")]
public class LocationController: ControllerBase
{
  public async Task<IActionResult> CreateLocations([FromBody] CreateLocationsRequestDto createLocationsRequestDto)
  {
    Console.WriteLine($"Received {createLocationsRequestDto.Locations.Length} locations to create.");
    return Ok(new HttpResponse
    {
      Data = null,
      Success = true,
      Message = "Locations created successfully."
    });
  }
}