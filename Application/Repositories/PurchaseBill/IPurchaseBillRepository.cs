namespace Enhanzer.Application.Repositories.PurchaseBill;

public interface IPurchaseBillRepository
{
  Task AddPurchaseBillAsync(Core.Entities.PurchaseBill purchaseBill);
  Task SaveChangesAsync();
}
