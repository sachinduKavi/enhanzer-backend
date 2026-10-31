using Enhanzer.Core.Entities;
using Enhanzer.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Enhanzer.Application.Repositories.Location;

public class LocationRepository(DatabaseContext context): ILocationRepository
{
  public async Task<List<LocationDetails>> GetLocationsAsync() =>
    await context.Set<LocationDetails>()
      .AsNoTracking()
      .OrderBy(l => l.LocationName)
      .ToListAsync();

  public async Task<List<string>> GetExistingCodesAsync(IReadOnlyCollection<string> codes) =>
    await context.Set<LocationDetails>()
      .Where(l => codes.Contains(l.LocationCode))
      .Select(l => l.LocationCode)
      .ToListAsync();

  public async Task AddCheckLocationAsync(LocationDetails location)
  {
    var exists = await context.Set<LocationDetails>()
      .AnyAsync(l => l.LocationCode == location.LocationCode);

    if (exists)
    {
      return;
    }

    await context.AddAsync(location);
  }

  public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}