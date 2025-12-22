using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.Interfaces;
using ProductCatalog.Application.Services;
using ProductCatalog.Infrastructure.Data;
using ProductCatalog.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ProductCatalogDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();

//For in-memory
//builder.Services.AddSingleton<IProductRepository, ProductRepository>();
// Why no IProductService?
// Earlier: Layered Architecture mindset:
// “Everything has an interface”

// Here: Clean Architecture mindset:
// “Interfaces belong at volatile boundaries, not everywhere.”
// “Clean Architecture is not about adding abstractions. It’s about placing abstractions where change is expected.”
// Repository = volatile boundary
// Why? => since External technology changes

//// Contd. 4) Improved testability of business rules
//// ✅ Clean Architecture – easy test (your structure)
//var service = new ProductService(new FakeProductRepository());
//service.Add(new Product { Price = -10 }); // throws


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

