using AutoMapper;
using Enhanzer.Core.Dtos.PurchaseBill;

namespace Enhanzer.Application.Mappings;

public class PurchaseBillProfile: Profile
{
  public PurchaseBillProfile()
  {
    CreateMap<Core.Entities.PurchaseBill, PurchaseBillDto>();
    CreateMap<CreatePurchaseBillRequestDto, Core.Entities.PurchaseBill>();
    CreateMap<Core.Entities.PurchaseBill, PurchaseOrderResponseDto>();
    CreateMap<Core.Entities.PurchaseBillItem, PurchaseBillItemResponseDto>()
      .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Qty))
      .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.StandardPrice))
      .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalSelling));
  }
}
