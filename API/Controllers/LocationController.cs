using Enhanzer.Application.Service.Location;
using Enhanzer.Core.Dtos.Location;
using Microsoft.AspNetCore.Mvc;
using HttpResponse = Enhanzer.Core.Dtos.Response.HttpResponse;

namespace Enhanzer.API.Controllers;


[ApiController]
[Route("[controller]")]
public class LocationController(ILocationService service): ControllerBase
{
  [HttpGet]
  public async Task<IActionResult> GetLocations()
  {
    return Ok(new HttpResponse
    {
      Data = await service.GetLocationsAsync(),
      Success = true,
      Message = "Locations retrieved successfully."
    });
  }

  [HttpPost]
  public async Task<IActionResult> CreateLocations([FromBody] CreateLocationsRequestDto createLocationsRequestDto)
  {
    Console.WriteLine($"Received {createLocationsRequestDto.Locations.Length} locations to create.");
    await service.CreateLocationAsync(createLocationsRequestDto);
    return Ok(new HttpResponse
    {
      Data = null,
      Success = true,
      Message = "Locations created successfully."
    });
  }
}