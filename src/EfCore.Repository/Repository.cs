using EfCore.Repository.Core;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using System.Linq.Expressions;

namespace EfCore.Repository;

public class Repository<TEntity> : ReadOnlyRepository<TEntity>, IRepository<TEntity>
where TEntity : class
{

    private bool _modified;

    public Repository(DbContext dbContext)
        : base(dbContext) { }

    public async Task AddAsync(TEntity entity)
    {
        var entry = await DbSet.AddAsync(entity).ConfigureAwait(false);
        HandleModified(entry);
    }

    public void Delete(TEntity entity)
    {
        var entry = DbSet.Remove(entity);
        HandleModified(entry);
    }

    public async Task DeleteAsync(Expression<Func<TEntity, bool>> expression)
    {
        var entity = await FindAsync(expression).ConfigureAwait(false);
        if (entity == null)
        {
            return;
        }

        var entry = DbSet.Remove(entity);

        HandleModified(entry);
    }

    private void HandleModified(EntityEntry entry)
    {
        var state = entry.State;
        _modified = state is EntityState.Deleted or EntityState.Modified or EntityState.Added;
    }

    public async ValueTask DisposeAsync()
    {
        if (!_modified)
        {
            return;
        }

        await DbContext.SaveChangesAsync();
    }

}
