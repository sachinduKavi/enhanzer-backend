namespace Enhanzer.Core.Dtos.PurchaseBill;

public class PurchaseOrderResponseDto
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public int TotalItems { get; set; }
  public decimal TotalQty { get; set; }

  public List<PurchaseBillItemResponseDto> Items { get; set; } = [];
}

public class PurchaseBillItemResponseDto
{
  public int Id { get; set; }
  public string ItemName { get; set; } = null!;
  public decimal Quantity { get; set; }
  public decimal Price { get; set; }
  public decimal TotalPrice { get; set; }
}