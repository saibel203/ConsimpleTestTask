using ConsimpleTestTask.Contracts.RepositoryAbstractions.Base;
using ConsimpleTestTask.Domain.Model.Entities;

namespace ConsimpleTestTask.Contracts.RepositoryAbstractions;

public interface IPurchaseRepository : IGenericRepository<Purchase>
{
    Task<IEnumerable<Purchase>> GetRecentPurchases(int days);
}