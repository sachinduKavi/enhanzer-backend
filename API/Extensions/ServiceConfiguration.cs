using Enhanzer.Application.Repositories.Location;
using Enhanzer.Application.Repositories.PurchaseBill;
using Enhanzer.Application.Service.Location;
using Enhanzer.Application.Service.PurchaseBill;

namespace Enhanzer.API.Extensions;

public static class ServiceConfiguration
{
  public static IServiceCollection AddAllServices(this IServiceCollection service)
  {
    service.AddRepositories();

    service.AddScoped<ILocationService, LocationService>();
    service.AddScoped<IPurchaseBillService, PurchaseBillService>();

    return service;
  }

  private static void AddRepositories(this IServiceCollection service)
  {
    service.AddScoped<ILocationRepository, LocationRepository>();
    service.AddScoped<IPurchaseBillRepository, PurchaseBillRepository>();
  }
}
