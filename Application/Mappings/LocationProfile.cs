using AutoMapper;
using Enhanzer.Core.Dtos.Location;
using Enhanzer.Core.Entities;

namespace Enhanzer.Application.Mappings;

public class LocationProfile: Profile
{
  public LocationProfile()
  {
    CreateMap<UserLocation, LocationDetails>();
    CreateMap<LocationDetails, LocationDto>();
  }
}