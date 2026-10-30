using Enhanzer.Core.Entities;

namespace Enhanzer.Application.Repositories.Location;

public interface ILocationRespository
{
  Task AddLocationAsync(LocationDetails location);
}