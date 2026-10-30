using Enhanzer.Core.Entities;
using Enhanzer.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Enhanzer.Application.Repositories.Location;

public class LocationRepository(DatabaseContext context): ILocationRepository
{
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
}