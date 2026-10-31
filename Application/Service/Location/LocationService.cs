using AutoMapper;
using Enhanzer.Application.Repositories.Location;
using Enhanzer.Core.Dtos.Location;
using Enhanzer.Core.Entities;

namespace Enhanzer.Application.Service.Location;

public class LocationService(ILocationRepository repository, IMapper _mapper): ILocationService
{
  public async Task<List<LocationDto>> GetLocationsAsync() =>
    _mapper.Map<List<LocationDto>>(await repository.GetLocationsAsync());

  public async Task CreateLocationAsync(CreateLocationsRequestDto createLocationsRequestDto)
  {
    foreach (var location in createLocationsRequestDto.Locations)
    {
      await repository.AddCheckLocationAsync(_mapper.Map<LocationDetails>(location));
    }

    await repository.SaveChangesAsync();
  }
}