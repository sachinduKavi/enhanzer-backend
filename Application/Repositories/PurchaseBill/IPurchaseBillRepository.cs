using Enhanzer.Core.Entities;

namespace Enhanzer.Application.Repositories.PurchaseBillRepository;

public interface IPurchaseBillRepository
{
  Task AddPurchaseBillAsync(Core.Entities.PurchaseBill purchaseBill);
  Task SaveChangesAsync();
  Task<List<PurchaseBill>> GetPurchaseBillsAsync();
}
