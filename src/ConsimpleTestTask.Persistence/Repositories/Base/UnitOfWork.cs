using ConsimpleTestTask.Contracts.RepositoryAbstractions;
using ConsimpleTestTask.Contracts.RepositoryAbstractions.Base;
using ConsimpleTestTask.Domain.Model.Entities.Base;

namespace ConsimpleTestTask.Persistence.Repositories.Base;

public class UnitOfWork : IUnitOfWork
{
    private readonly ConsimpleDbContext _context;
    
    private readonly Dictionary<Type, object> _repositories = new();
    private bool _disposed;

    public IPurchaseRepository PurchaseRepository { get; private set; }
    public IPurchaseItemRepository PurchaseItemRepository { get; private set; }

    public UnitOfWork(ConsimpleDbContext context)
    {
        _context = context;

        PurchaseRepository = new PurchaseRepository(context);
        PurchaseItemRepository = new PurchaseItemRepository(context);
    }

    public IGenericRepository<TEntity> GetRepository<TEntity>()
        where TEntity : BaseEntity
    {
        if (_repositories.ContainsKey(typeof(TEntity)))
        {
            return (IGenericRepository<TEntity>)_repositories[typeof(TEntity)];
        }

        var repository = new GenericRepository<TEntity>(_context);
        _repositories.Add(typeof(TEntity), repository);
        return repository;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public Task<int> CommitAsync(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    ~UnitOfWork()
    {
        Dispose(false);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                _context.Dispose();
        _disposed = true;
    }
}