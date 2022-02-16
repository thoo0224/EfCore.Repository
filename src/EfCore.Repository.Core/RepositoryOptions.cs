using Microsoft.EntityFrameworkCore;

namespace EfCore.Repository.Core;

public class RepositoryOptions
{

    public delegate DbContext CreateDbContextDelegate();
    public CreateDbContextDelegate CreateDbContext { get; set; }

    public Type DbContextType { get; set; }
    public object DbContextFactory { get; internal set; }

}
