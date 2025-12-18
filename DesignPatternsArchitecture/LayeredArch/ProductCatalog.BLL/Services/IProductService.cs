using ProductCatalog.Core.Models;

namespace ProductCatalog.BLL.Services;

public interface IProductService
{
    // Light CQRS(Command–Query Responsibility Segregation) concept:
    // Commands change state; queries only read.
    IEnumerable<Product> GetAll();      // Query
    Product Add(Product product);       // Command
    bool Update(Product product);       // Command
    bool Delete(int id);                // Command
}
