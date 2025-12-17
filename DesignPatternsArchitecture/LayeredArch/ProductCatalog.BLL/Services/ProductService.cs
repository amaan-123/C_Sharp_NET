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
        // Business rules
        if (string.IsNullOrWhiteSpace(product.Name))
            throw new ArgumentException("Product name is required");

        if (product.Price <= 0)
            throw new ArgumentException("Price must be greater than zero");

        if (product.Stock < 0)
            throw new ArgumentException("Stock cannot be negative");

        return _repository.Add(product);
    }
}
