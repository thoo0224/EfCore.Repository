using EfCore.Repository.Test.Database.Objects;

using Microsoft.EntityFrameworkCore;

namespace EfCore.Repository.Test.Database;

public class ApplicationDbContext : DbContext
{

    public DbSet<Product> Products { get; set; }

    public ApplicationDbContext(DbContextOptions options)
        : base(options) { }

}
