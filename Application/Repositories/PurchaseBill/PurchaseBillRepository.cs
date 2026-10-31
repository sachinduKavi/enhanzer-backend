using Enhanzer.Infrastructure.Database;

namespace Enhanzer.Application.Repositories.PurchaseBill;

public class PurchaseBillRepository(DatabaseContext context): IPurchaseBillRepository
{
  public async Task AddPurchaseBillAsync(Core.Entities.PurchaseBill purchaseBill) =>
    await context.AddAsync(purchaseBill);

  public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}
