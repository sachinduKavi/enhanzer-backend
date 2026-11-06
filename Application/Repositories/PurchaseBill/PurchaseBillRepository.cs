using Enhanzer.Core.Entities;
using Enhanzer.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Enhanzer.Application.Repositories.PurchaseBillRepository;

public class PurchaseBillRepository(DatabaseContext context): IPurchaseBillRepository
{
  public async Task AddPurchaseBillAsync(Core.Entities.PurchaseBill purchaseBill) =>
    await context.AddAsync(purchaseBill);

  public async Task SaveChangesAsync() => await context.SaveChangesAsync();

  public async Task<List<PurchaseBill>> GetPurchaseBillsAsync() => await context.PurchaseBills
      .Include(i => i.Items)
      .Take(10)
      .ToListAsync();
}
