namespace Enhanzer.Core.Dtos.Location;


public class UserLocation
{
  public string LocationCode { get; set; } = null!;
  public string? LocationName { get; set; }
  public int? StockHandle { get; set; }
  public string? Address { get; set; }
  public string? Phone { get; set; }
  public bool? Status { get; set; }
}

public class CreateLocationsRequestDto
{
  public UserLocation[] Locations { get; set; } = [];
}