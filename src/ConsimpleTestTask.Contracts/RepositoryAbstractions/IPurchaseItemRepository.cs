using ConsimpleTestTask.Contracts.RepositoryAbstractions.Base;
using ConsimpleTestTask.Domain.Model.Entities;

namespace ConsimpleTestTask.Contracts.RepositoryAbstractions;

public interface IPurchaseItemRepository : IGenericRepository<PurchaseItem>
{
    Task<IEnumerable<PurchaseItem>> GetPurchaseItemsByClientId(int clientId);
}