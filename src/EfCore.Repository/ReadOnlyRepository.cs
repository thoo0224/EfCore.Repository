using EfCore.Repository.Core;

using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace EfCore.Repository;

public class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity>
where TEntity : class
{

    public DbContext DbContext { get; }
    public DbSet<TEntity> DbSet { get; set; }

    public ReadOnlyRepository(DbContext dbContext)
    {
        DbContext = dbContext;
        DbSet = DbContext.Set<TEntity>();
    }

    public IQueryable<TEntity> GetAll(bool tracking = true)
    {
        var queryable = DbSet.AsQueryable();
        return tracking
            ? queryable
            : queryable.AsNoTracking();
    }

    public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true)
    {
        var entity = await GetAll(tracking).FirstOrDefaultAsync(expression)
            .ConfigureAwait(false);

        return entity;
    }

}
