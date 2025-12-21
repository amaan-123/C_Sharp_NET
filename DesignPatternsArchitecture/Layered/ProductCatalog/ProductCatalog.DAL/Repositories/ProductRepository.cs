using ProductCatalog.Core.Models;
using ProductCatalog.DAL.Data;

namespace ProductCatalog.DAL.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductCatalogDbContext _db;
    public ProductRepository(ProductCatalogDbContext db)
    {
        _db = db;
    }

    public IEnumerable<Product> GetAll() => _db.Products.ToList();

    public Product? GetById(int id) => _db.Products.Find(id);
    // why Find and not SingleOrDefault/First...?
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
    // In-memory repository:
    //private readonly List<Product> _products = new();
    //private int _nextId = 1;

    //public IEnumerable<Product> GetAll()
    //{
    //    return _products;
    //}

    //public Product? GetById(int id)
    //{
    //    return _products.FirstOrDefault(p => p.Id == id);
    //}

    //public Product Add(Product product)
    //{
    //    product.Id = _nextId++;
    //    _products.Add(product);
    //    return product;
    //}
    //public bool Update(Product product)
    //{
    //    var existing = GetById(product.Id);
    //    if (existing is null) return false;

    //    existing.Name = product.Name;
    //    existing.Price = product.Price;
    //    existing.Stock = product.Stock;
    //    existing.Category = product.Category;

    //    return true;
    //}
    //public bool Delete(int id)
    //{
    //    var product = GetById(id);
    //    if (product is null) return false;

    //    _products.Remove(product);
    //    return true;
    //}

}
