using EfCore.Repository.Core;

namespace EfCore.Repository;

public static class RepositoryExt
{

    /*
     * IRepository<TEntity> CreateDefault<TEntity>();

    IReadOnlyRepository<TEntity> CreateDefaultReadOnly<TEntity>();
     */

    public static Repository<TEntity> CreateDefault<TEntity>(this IRepositoryFactory factory)
    where TEntity : class
        => factory.Create<Repository<TEntity>>();

    public static ReadOnlyRepository<TEntity> CreateDefaultReadOnly<TEntity>(this IRepositoryFactory factory)
        where TEntity : class
        => factory.Create<ReadOnlyRepository<TEntity>>();

}
