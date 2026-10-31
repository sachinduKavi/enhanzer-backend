namespace Enhanzer.Core.Dtos.PurchaseBill;

public class CreatePurchaseBillItemDto
{
  public string ItemName { get; set; } = null!;
  public string BatchCode { get; set; } = null!;
  public decimal StandardCost { get; set; }
  public decimal StandardPrice { get; set; }
  public decimal Qty { get; set; }
  public decimal FreeQty { get; set; }
  public decimal Discount { get; set; }
}

public class CreatePurchaseBillRequestDto
{
  public string CreatedBy { get; set; } = null!;
  public CreatePurchaseBillItemDto[] Items { get; set; } = [];
}
