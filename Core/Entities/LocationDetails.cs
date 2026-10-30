using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enhanzer.Core.Entities;

[Table("Location_Details")]
public class LocationDetails
{
  [Key]
  [Column("Location_Code", TypeName = "varchar(20)")]
  public string LocationCode { get; set; } = null!;

  [Column("Location_Name", TypeName = "varchar(100)")]
  public string? LocationName { get; set; }

  [Column("Stock_Handle", TypeName = "int")]
  public int? StockHandle { get; set; }
  
  [Column("Address", TypeName = "text")]
  public string? Address { get; set; }

  [Column("Phone", TypeName = "varchar(15)")]
  public string? Phone { get; set; }

  [Column("Status", TypeName = "tinyint(1)")]
  public bool? Status { get; set; }
}