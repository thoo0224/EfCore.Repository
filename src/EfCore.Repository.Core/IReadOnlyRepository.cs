using System.Linq.Expressions;

namespace EfCore.Repository.Core;

public interface IReadOnlyRepository { }

public interface IReadOnlyRepository<TEntity> : IReadOnlyRepository, IRepositoryBase
{

    IQueryable<TEntity> GetAll(bool tracking = true);

    Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true);

}
