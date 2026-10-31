using Enhanzer.Core.Dtos.Location;

namespace Enhanzer.Application.Service.Location;


public interface ILocationService
{
  Task<List<LocationDto>> GetLocationsAsync();
  Task CreateLocationAsync(CreateLocationsRequestDto createLocationsRequestDto);
}