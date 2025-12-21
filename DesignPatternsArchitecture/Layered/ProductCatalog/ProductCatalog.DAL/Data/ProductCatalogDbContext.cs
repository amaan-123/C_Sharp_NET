using Microsoft.EntityFrameworkCore;
using ProductCatalog.Core.Models;

namespace ProductCatalog.DAL.Data
{
    public class ProductCatalogDbContext : DbContext
    {
        public ProductCatalogDbContext(DbContextOptions<ProductCatalogDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products => Set<Product>();
    }
}
