<div align="center">

# EfCore.Repository

About
.NET 6 Repository library for Entity Framework Core

[![GitHub release](https://img.shields.io/github/v/release/thoo0224/EfCore.Repository?logo=github)](https://github.com/thoo0224/EfCore.Repository/releases/latest) [![Nuget](https://img.shields.io/nuget/v/Thoo.EfCore.Repository?logo=nuget)](https://www.nuget.org/packages/Thoo.EfCore.Repository) [![Nuget DLs](https://img.shields.io/nuget/dt/Thoo.EfCore.Repository?logo=nuget)](https://www.nuget.org/packages/Thoo.EfCore.Repository) [![GitHub issues](https://img.shields.io/github/issues/thoo0224/EfCore.Repository.Net?logo=github)](https://github.com/thoo0224/EfCore.Repository/issues) [![GitHub License](https://img.shields.io/github/license/thoo0224/EfCore.Repository.Net)](https://github.com/thoo0224/EfCore.Repository/blob/master/LICENSE.txt)

</div>

## Example Usage

```cs
services.AddRepositories<ApplicationDbContext>();

private readonly IRepositoryFactory _factory;

await using var repository = _factory.CreateDefault<Product>();
await repository.AddAsync(new Product {
    Id = Guid.NewGuid(),
    Name = "Jetbrains Rider"
});
```

### NuGet

```md
Install-Package Thoo.EfCore.Repository
```

### Contribute

Any type of contribution is appreciated.