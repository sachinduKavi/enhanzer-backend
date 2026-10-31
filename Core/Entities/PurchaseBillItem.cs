using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enhanzer.Core.Entities;

[Table("Purchase_Bill_Item")]
public class PurchaseBillItem
{
  [Key]
  [Column("Id")]
  public int Id { get; set; }

  [Column("Purchase_Bill_Id")]
  public int PurchaseBillId { get; set; }

  [ForeignKey(nameof(PurchaseBillId))]
  public PurchaseBill? PurchaseBill { get; set; }

  [Column("Item_Name", TypeName = "varchar(50)")]
  public string ItemName { get; set; } = null!;

  [Column("Batch_Code", TypeName = "varchar(20)")]
  public string BatchCode { get; set; } = null!;

  [ForeignKey(nameof(BatchCode))]
  public LocationDetails? Batch { get; set; }

  [Column("Standard_Cost", TypeName = "decimal(18,2)")]
  public decimal StandardCost { get; set; }

  [Column("Standard_Price", TypeName = "decimal(18,2)")]
  public decimal StandardPrice { get; set; }

  [Column("Margin", TypeName = "decimal(18,2)")]
  public decimal Margin { get; set; }

  [Column("Qty", TypeName = "decimal(18,2)")]
  public decimal Qty { get; set; }

  [Column("Free_Qty", TypeName = "decimal(18,2)")]
  public decimal FreeQty { get; set; }

  [Column("Discount", TypeName = "decimal(5,2)")]
  public decimal Discount { get; set; }

  [Column("Total_Cost", TypeName = "decimal(18,2)")]
  public decimal TotalCost { get; set; }

  [Column("Total_Selling", TypeName = "decimal(18,2)")]
  public decimal TotalSelling { get; set; }
}
