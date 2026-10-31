using Enhanzer.Core.Entities;

namespace Enhanzer.Application.Repositories.Location;

public interface ILocationRepository
{
  Task<List<LocationDetails>> GetLocationsAsync();
  Task AddCheckLocationAsync(LocationDetails location);
  Task SaveChangesAsync();
}