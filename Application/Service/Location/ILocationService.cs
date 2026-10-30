using Enhanzer.Core.Dtos.Location;

namespace Enhanzer.Application.Service.Location;


public interface ILocationService
{
  Task CreateLocationAsync(CreateLocationsRequestDto createLocationsRequestDto);
}