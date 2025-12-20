using ProductCatalog.BLL.Services;
using ProductCatalog.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Dependency Injection (Layer wiring)

// Learning point:
// builder.Services.AddScoped<IProductRepository, ProductRepository>();
// AddScoped means:
//“Create one instance per HTTP request”
//That is perfect for EF Core, but not for in-memory storage.
//Each HTTP request gets a new ProductRepository instance
//Each instance has its own fresh _products = new List<Product>()
//So:
//POST → adds product → request ends → object destroyed
//GET → new repository → empty list

//Now:
//One repository instance
//One shared in-memory list
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
