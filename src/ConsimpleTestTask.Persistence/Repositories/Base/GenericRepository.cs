using System.Linq.Expressions;
using ConsimpleTestTask.Contracts.RepositoryAbstractions.Base;
using ConsimpleTestTask.Domain.Model.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace ConsimpleTestTask.Persistence.Repositories.Base;

public class GenericRepository<TEntity>(ConsimpleDbContext context) : IGenericRepository<TEntity>
    where TEntity : BaseEntity
{
    protected ConsimpleDbContext Context = context;

    public async Task<TEntity?> GetById(Guid id)
    {
        return await Context.Set<TEntity>().FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }

    public IQueryable<TEntity> FindQueryable(Expression<Func<TEntity, bool>> expression,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>().Where(expression);
        return orderBy != null ? orderBy(query) : query;
    }

    public Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>>? expression,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query =
            expression != null ? Context.Set<TEntity>().Where(expression) : Context.Set<TEntity>();
        return orderBy != null
            ? orderBy(query).ToListAsync(cancellationToken)
            : query.ToListAsync(cancellationToken);
    }

    public Task<List<TEntity>> FindAllAsync(CancellationToken cancellationToken)
    {
        return Context.Set<TEntity>().ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression,
        string includeProperties)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>().AsQueryable();

        query = includeProperties.Split(new[] { ',' },
            StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty)
            => current.Include(includeProperty));

        return await query.SingleOrDefaultAsync(expression);
    }

    public async Task<TEntity> Add(TEntity entity)
    {
        return (await Context.Set<TEntity>().AddAsync(entity)).Entity;
    }

    public void Update(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        Context.Set<TEntity>().UpdateRange(entities);
    }

    public void Delete(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }
}