using ConsimpleTestTask.Contracts.RepositoryAbstractions;
using ConsimpleTestTask.Domain.Model.Entities;
using ConsimpleTestTask.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace ConsimpleTestTask.Persistence.Repositories;

public class PurchaseItemRepository(ConsimpleDbContext context)
    : GenericRepository<PurchaseItem>(context), IPurchaseItemRepository
{
    public async Task<IEnumerable<PurchaseItem>> GetPurchaseItemsByClientId(int clientId)
    {
        IEnumerable<Purchase> purchases = await Context.Purchases
            .Where(p => p.ClientId == clientId)
            .ToListAsync();

        IEnumerable<PurchaseItem> purchaseItems = await Context.PurchaseItems
            .Where(p => purchases.Select(purchase => purchase.Id).Contains(p.PurchaseId))
            .Include(p => p.Product)
            .Include(p => p.Product.ProductCategory)
            .Include(p => p.Purchase)
            .Include(p => p.Purchase.Client)
            .ToListAsync();

        return purchaseItems;
    }
}