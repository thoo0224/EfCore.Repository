using System.Linq.Expressions;

namespace EfCore.Repository.Core;

public interface IRepository { }

public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>, IRepository, IAsyncDisposable
{

    Task AddAsync(TEntity entity);

    void Delete(TEntity entity);

    Task DeleteAsync(Expression<Func<TEntity, bool>> expression);

}
