using Enhanzer.Core.Dtos.PurchaseBill;

namespace Enhanzer.Application.Service.PurchaseBill;

public interface IPurchaseBillService
{
  Task<PurchaseBillDto> CreatePurchaseBillAsync(CreatePurchaseBillRequestDto createPurchaseBillRequestDto);
}
