using Enhanzer.Application.Repositories.Location;

namespace Enhanzer.API.Extensions;

public static class ServiceConfiguration
{
  public static IServiceCollection AddAllServices(this IServiceCollection service)
  {
    service.AddRepositories();

    
    return service;
  }

  private static void AddRepositories(this IServiceCollection service)
  {
    service.AddScoped<ILocationRespository, LocationRepository>();
  }
}