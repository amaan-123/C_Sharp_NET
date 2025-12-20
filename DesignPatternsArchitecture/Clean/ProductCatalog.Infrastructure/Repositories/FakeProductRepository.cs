using ProductCatalog.Application.Interfaces;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Infrastructure.Repositories;
////4) Difficult to isolate and test business rules
////➡️ Clean advantage: Improved testability of business rules

////❌ Layered Architecture – hard to test
////// Needs DB, config, DI container
////var service = new ProductService(new ProductDbContext(...));

////Problem
////Tests are slow
////Tests break due to infra issues
////Not unit tests anymore


//✅ Verification checklist
//[] Business rules can be tested with fake repos
//[] No ASP.NET / EF references in test project

////✅ Clean Architecture – easy test(your structure)
public class FakeProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();
    private int _nextId = 1;
    // Focus on these below two changed methods to test business logic in isolation:
    // No framework, no DB, no API
    public Product Add(Product p) => p;
    public Product? GetById(int id) => null;




    public IEnumerable<Product> GetAll()
    {
        return _products;
    }

    public bool Update(Product product)
    {
        var existing = GetById(product.Id);
        if (existing is null) return false;

        existing.Name = product.Name;
        existing.Price = product.Price;
        existing.Stock = product.Stock;
        existing.Category = product.Category;

        return true;
    }
    public bool Delete(int id)
    {
        var product = GetById(id);
        if (product is null) return false;

        _products.Remove(product);
        return true;
    }

}
