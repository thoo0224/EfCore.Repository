using EfCore.Repository;
using EfCore.Repository.Test.Database;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositories<ApplicationDbContext>();
builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(options =>
{
    options.UseInMemoryDatabase("db");
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
