using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enhanzer.Core.Entities;

[Table("Purchase_Bill")]
public class PurchaseBill
{
  [Key]
  [Column("Id")]
  public int Id { get; set; }

  [Column("Created_At")]
  public DateTime CreatedAt { get; set; }

  [Column("Created_By", TypeName = "varchar(100)")]
  public string CreatedBy { get; set; } = null!;

  [Column("Total_Items")]
  public int TotalItems { get; set; }

  [Column("Total_Qty", TypeName = "decimal(18,2)")]
  public decimal TotalQty { get; set; }

  public List<PurchaseBillItem> Items { get; set; } = [];
}
