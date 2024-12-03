using ConsimpleTestTask.Contracts.RepositoryAbstractions;
using ConsimpleTestTask.Domain.Model.Entities;
using ConsimpleTestTask.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace ConsimpleTestTask.Persistence.Repositories;

public class PurchaseRepository(ConsimpleDbContext context) : GenericRepository<Purchase>(context), IPurchaseRepository
{
    public async Task<IEnumerable<Purchase>> GetRecentPurchases(int days)
    {
        DateTime cutOffDays = DateTime.Now.AddDays(-days);

        IEnumerable<Purchase> purchases =
            await Context.Purchases.Where(p => p.Date >= cutOffDays)
                .Include(p => p.Client).ToListAsync();

        return purchases;
    }
}