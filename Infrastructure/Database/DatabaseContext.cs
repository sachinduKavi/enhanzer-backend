using Enhanzer.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Enhanzer.Infrastructure.Database;

public class DatabaseContext(DbContextOptions<DatabaseContext> options): DbContext(options)
{
  public DbSet<LocationDetails> LocationDetails { get; set; }
  public DbSet<PurchaseBill> PurchaseBills { get; set; }
  public DbSet<PurchaseBillItem> PurchaseBillItems { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // A location used as a batch on a saved bill must not be deleted with its bill rows.
    modelBuilder.Entity<PurchaseBillItem>()
      .HasOne(item => item.Batch)
      .WithMany()
      .HasForeignKey(item => item.BatchCode)
      .OnDelete(DeleteBehavior.Restrict);
  }
}