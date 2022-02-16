using EfCore.Repository.Core;
using EfCore.Repository.Test.Database.Objects;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Repository.Test.Controllers;

[ApiController]
public class ProductController : ControllerBase
{

    private readonly IRepositoryFactory _repositoryFactory;

    public ProductController(IRepositoryFactory repositoryFactory)
    {
        _repositoryFactory = repositoryFactory;
    }

    [HttpGet("/api/products")]
    public async Task<IActionResult> GetProducts()
    {
        var repository = _repositoryFactory.CreateDefaultReadOnly<Product>();
        var products = await repository.GetAll(false).ToListAsync();

        return Ok(products);
    }

    [HttpPost("/api/products")]
    public async Task<IActionResult> AddProduct(string name)
    {
        await using var repository = _repositoryFactory.CreateDefault<Product>();
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = name
        };

        await repository.AddAsync(product);
        return Ok(product);
    }

    [HttpDelete("/api/products")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        await using var repository = _repositoryFactory.CreateDefault<Product>();
        await repository.DeleteAsync(product => product.Id.ToString().Equals(id));

        return Ok();
    }

}
