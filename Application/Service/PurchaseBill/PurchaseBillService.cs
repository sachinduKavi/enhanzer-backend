using AutoMapper;
using Enhanzer.Application.Repositories.Location;
using Enhanzer.Application.Repositories.PurchaseBillRepository;
using Enhanzer.Core.Dtos.PurchaseBill;
using Enhanzer.Core.Entities;

namespace Enhanzer.Application.Service.PurchaseBill;

public class PurchaseBillService(
  IPurchaseBillRepository repository,
  ILocationRepository locationRepository,
  IMapper _mapper): IPurchaseBillService
{
  private static readonly string[] ItemNames = ["Mango", "Apple", "Banana", "Orange", "Grapes", "Kiwi", "Strawberry"];

  public async Task<List<PurchaseOrderResponseDto>> FetchPurchaseBills()
  {
    var purchaseBills = await repository.GetPurchaseBillsAsync();
    return _mapper.Map<List<PurchaseOrderResponseDto>>(purchaseBills);
  }

  public async Task<PurchaseBillDto> CreatePurchaseBillAsync(CreatePurchaseBillRequestDto createPurchaseBillRequestDto)
  {
    await ValidateAsync(createPurchaseBillRequestDto);

    var items = createPurchaseBillRequestDto.Items.Select(item => new PurchaseBillItem
    {
      ItemName = item.ItemName,
      BatchCode = item.BatchCode,
      StandardCost = item.StandardCost,
      StandardPrice = item.StandardPrice,
      Margin = PurchaseBillCalculator.Margin(item.StandardCost, item.StandardPrice),
      Qty = item.Qty,
      FreeQty = item.FreeQty,
      Discount = item.Discount,
      TotalCost = PurchaseBillCalculator.TotalCost(item.StandardCost, item.Qty, item.Discount),
      TotalSelling = PurchaseBillCalculator.TotalSelling(item.StandardPrice, item.Qty)
    }).ToList();

    var purchaseBill = new Core.Entities.PurchaseBill
    {
      CreatedAt = DateTime.UtcNow,
      CreatedBy = createPurchaseBillRequestDto.CreatedBy.Trim(),
      TotalItems = items.Count,
      TotalQty = PurchaseBillCalculator.Sum(items.Select(item => item.Qty)),
      Items = items
    };

    await repository.AddPurchaseBillAsync(purchaseBill);
    await repository.SaveChangesAsync();

    return _mapper.Map<PurchaseBillDto>(purchaseBill);
  }

  private async Task ValidateAsync(CreatePurchaseBillRequestDto request)
  {
    if (string.IsNullOrWhiteSpace(request.CreatedBy))
    {
      throw new ArgumentException("The user saving the bill is required.");
    }

    if (request.Items.Length == 0)
    {
      throw new ArgumentException("Add at least one item before saving the bill.");
    }

    foreach (var (item, index) in request.Items.Select((item, index) => (item, index + 1)))
    {
      if (!ItemNames.Contains(item.ItemName))
        throw new ArgumentException($"Row {index}: '{item.ItemName}' is not a valid item.");
      if (item.StandardCost < 0 || item.StandardPrice < 0)
        throw new ArgumentException($"Row {index}: standard cost and price must be 0 or more.");
      if (item.Qty <= 0)
        throw new ArgumentException($"Row {index}: qty must be more than 0.");
      if (item.FreeQty < 0)
        throw new ArgumentException($"Row {index}: free qty must be 0 or more.");
      if (item.Discount < 0 || item.Discount > 100)
        throw new ArgumentException($"Row {index}: discount must be between 0 and 100.");
    }

    var batchCodes = request.Items.Select(item => item.BatchCode).Distinct().ToList();
    var existingCodes = await locationRepository.GetExistingCodesAsync(batchCodes);
    var unknownCodes = batchCodes.Except(existingCodes).ToList();

    if (unknownCodes.Count > 0)
    {
      throw new ArgumentException($"Unknown batch: {string.Join(", ", unknownCodes)}.");
    }
  }
}
