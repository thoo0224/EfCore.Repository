using EfCore.Repository.Core;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace EfCore.Repository;

public static class ServiceCollectionExt
{

    public static IServiceCollection AddRepositories<TContext>(this IServiceCollection services)
    where TContext : DbContext
    {
        var options = new RepositoryOptions
        {
            DbContextType = typeof(TContext)
        };

        services.AddSingleton<IRepositoryFactory, RepositoryFactory>();
        services.AddSingleton(options);

        services.TryAddTransient(provider =>
        {
            var dbContextFactoryType = typeof(IDbContextFactory<>).MakeGenericType(options.DbContextType);
            if (options.CreateDbContext == null)
            {
                var factory = provider.GetRequiredService(dbContextFactoryType);
                var createDbContextMethod = dbContextFactoryType.GetMethod("CreateDbContext");

                options.CreateDbContext 
                    = (RepositoryOptions.CreateDbContextDelegate) Delegate.CreateDelegate(typeof(RepositoryOptions.CreateDbContextDelegate), factory, createDbContextMethod!);
            }

            return options.CreateDbContext();
        });

        return services;
    }

}
