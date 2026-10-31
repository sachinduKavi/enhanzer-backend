using AutoMapper;
using Enhanzer.Core.Dtos.PurchaseBill;

namespace Enhanzer.Application.Mappings;

public class PurchaseBillProfile: Profile
{
  public PurchaseBillProfile()
  {
    CreateMap<Core.Entities.PurchaseBill, PurchaseBillDto>();
  }
}
