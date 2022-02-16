using EfCore.Repository.Core;

using Microsoft.Extensions.DependencyInjection;

namespace EfCore.Repository;

public class RepositoryFactory : IRepositoryFactory
{

    private readonly IServiceProvider _serviceProvider;

    public RepositoryFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public TRepository Create<TRepository>() 
    where TRepository : IRepositoryBase
        => ActivatorUtilities.CreateInstance<TRepository>(_serviceProvider);

}
