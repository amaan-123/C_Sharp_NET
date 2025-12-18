using ProductCatalog.Core.Models;

namespace ProductCatalog.BLL.Services;

public interface IProductService
{
    IEnumerable<Product> GetAll();
    Product Add(Product product);
    bool Update(Product product);
    bool Delete(int id);
}
