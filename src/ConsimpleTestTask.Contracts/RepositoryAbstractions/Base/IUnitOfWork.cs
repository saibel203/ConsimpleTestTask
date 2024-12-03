using ConsimpleTestTask.Domain.Model.Entities.Base;

namespace ConsimpleTestTask.Contracts.RepositoryAbstractions.Base;

public interface IUnitOfWork : IDisposable
{
    public IPurchaseRepository PurchaseRepository { get; }
    public IPurchaseItemRepository PurchaseItemRepository { get; }

    public IGenericRepository<TEntity> GetRepository<TEntity>()
        where TEntity : BaseEntity;

    Task<int> CommitAsync(CancellationToken cancellationToken);
}