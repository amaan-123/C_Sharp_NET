using ProductCatalog.Application.Interfaces;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Infrastructure.Data;

namespace ProductCatalog.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductCatalogDbContext _db;

    public ProductRepository(ProductCatalogDbContext db)
    {
        _db = db;
    }

    //private readonly List<Product> _products = new();
    //private int _nextId = 1;

    public IEnumerable<Product> GetAll()
    {
        return _db.Products.ToList();
    }

    public Product? GetById(int id)
    {
        return _db.Products.Find(id);
    }

    public Product Add(Product product)
    {
        _db.Products.Add(product);
        _db.SaveChanges();
        return product;
    }
    public bool Update(Product product)
    {
        if (!_db.Products.Any(p => p.Id == product.Id))
            return false;

        _db.Products.Update(product);
        _db.SaveChanges();
        return true;
    }
    public bool Delete(int id)
    {
        var product = _db.Products.Find(id);
        if (product is null) return false;

        _db.Products.Remove(product);
        _db.SaveChanges();
        return true;
    }

}
