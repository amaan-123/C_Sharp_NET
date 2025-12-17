using ProductCatalog.Core.Models;

namespace ProductCatalog.DAL.Repositories;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product? GetById(int id);
    Product Add(Product product);
}
