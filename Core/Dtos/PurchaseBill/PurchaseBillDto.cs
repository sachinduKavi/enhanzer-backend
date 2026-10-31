namespace Enhanzer.Core.Dtos.PurchaseBill;

public class PurchaseBillDto
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public int TotalItems { get; set; }
  public decimal TotalQty { get; set; }
}
