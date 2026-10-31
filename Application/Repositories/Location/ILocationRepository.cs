using Enhanzer.Core.Entities;

namespace Enhanzer.Application.Repositories.Location;

public interface ILocationRepository
{
  Task<List<LocationDetails>> GetLocationsAsync();
  Task<List<string>> GetExistingCodesAsync(IReadOnlyCollection<string> codes);
  Task AddCheckLocationAsync(LocationDetails location);
  Task SaveChangesAsync();
}