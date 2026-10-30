using Enhanzer.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Enhanzer.Application.Repositories.Location;

public class LocationRepository(DbContext context): ILocationRespository
{
  public async Task AddLocationAsync(LocationDetails location) => await context.AddAsync(location);
}