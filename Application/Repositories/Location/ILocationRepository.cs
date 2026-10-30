using Enhanzer.Core.Entities;

namespace Enhanzer.Application.Repositories.Location;

public interface ILocationRepository
{
  Task AddCheckLocationAsync(LocationDetails location);
}