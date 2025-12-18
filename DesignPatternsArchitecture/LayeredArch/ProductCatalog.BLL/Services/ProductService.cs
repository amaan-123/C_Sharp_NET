using ProductCatalog.Core.Models;
using ProductCatalog.DAL.Repositories;

namespace ProductCatalog.BLL.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Product> GetAll()
    {
        return _repository.GetAll();
    }

    public Product Add(Product product)
    {
        Validate(product);
        return _repository.Add(product);
    }

    public bool Update(Product product)
    {
        Validate(product);
        return _repository.Update(product);
    }
    public bool Delete(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Invalid product id");

        return _repository.Delete(id);
    }
    private static void Validate(Product product)
    {
        if (string.IsNullOrWhiteSpace(product.Name))
            throw new ArgumentException("Product name is required");

        if (product.Price <= 0)
            throw new ArgumentException("Price must be greater than zero");

        if (product.Stock < 0)
            throw new ArgumentException("Stock cannot be negative");
    }
}
