namespace EfCore.Repository.Core;

public interface IRepositoryFactory
{

    TRepository Create<TRepository>()
        where TRepository : IRepositoryBase;

}
