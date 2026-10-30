using Enhanzer.Application.Repositories.Location;
using Enhanzer.Application.Service.Location;

namespace Enhanzer.API.Extensions;

public static class ServiceConfiguration
{
  public static IServiceCollection AddAllServices(this IServiceCollection service)
  {
    service.AddRepositories();

    service.AddScoped<ILocationService, LocationService>();
    
    return service;
  }

  private static void AddRepositories(this IServiceCollection service)
  {
    service.AddScoped<ILocationRepository, LocationRepository>();
  }
}