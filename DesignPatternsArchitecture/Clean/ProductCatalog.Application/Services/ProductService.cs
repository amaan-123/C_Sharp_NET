using ProductCatalog.Application.Interfaces;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.Services;

public class ProductService //: IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }
    // 1) Contd.: Why the above abstraction via interface DI fixes it
    //    Business logic depends on abstraction
    //    Infrastructure is pushed outward
    //    Dependency direction is inward only
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
    // Contd. 3) Database and UI are implementation details
    //public bool IsProductAvailable(int id)
    //{
    //    var product = _repository.GetById(id);
    //    return (product != null) && (product.Stock > 0);
    //}
    private static void Validate(Product product)
    {
        // Business rules must fail fast
        ArgumentNullException.ThrowIfNull(product);

        if (string.IsNullOrWhiteSpace(product.Name))
            throw new ArgumentException("Product name is required");

        if (product.Price <= 0)
            throw new ArgumentException("Price must be greater than zero");

        if (product.Stock < 0)
            throw new ArgumentException("Stock cannot be negative");
    }
}

//1) Business logic often depends on Data Access Layer
//➡️ Clean advantage: Business logic is fully isolated and protected

//// BLL (Layered, wrong)
//public class ProductService
//{
//    private readonly ProductDbContext _db;

//    public ProductService(ProductDbContext db)
//    {
//        _db = db;
//    }

//    public void Add(Product product)
//    {
//        if (product.Price <= 0)
//            throw new Exception("Invalid price");

//        _db.Products.Add(product);
//        _db.SaveChanges();
//    }
//}

////Problem:
////Business logic depends on EF Core
////You cannot run business rules without database
////Violates separation of concerns

////## ✅ Verification checklist
////*[] Application layer references ** no Infrastructure**
////*[] Business logic compiles without EF Core package


////3) DB or framework changes impact business logic
////➡️ Clean advantage: Database and UI are implementation details
////❌ Layered Architecture – typical failure
//// BLL logic tied to EF Core LINQ
//public bool IsProductAvailable(int id)
//    {
//        return _db.Products.Any(p => p.Id == id && p.Stock > 0);
//    }
////Problem:
////    Switching DB or storage breaks logic
////    Business logic “speaks SQL/EF”

////✅ Clean Architecture – correct way(your design)
//// Application
//public bool IsProductAvailable(int id)
//    {
//        var product = _repository.GetById(id);
//        return product != null && product.Stock > 0;
//    }
////Why this fixes it
////    Business logic speaks business language
////    Storage changes don’t ripple inward

////## ✅ Verification checklist
////*[] No LINQ-to-Entities inside Application
////*[] Repository hides query technology

//5) UI and data concerns leak into core logic
//➡️ Clean advantage: Clear dependency direction reduces coupling

//❌ Layered Architecture – leakage example
//// BLL depending on HTTP concepts
//public IActionResult Add(Product product)
//{
//    if (!ModelState.IsValid)
//        return BadRequest();
//}

//Problem
//Business logic knows about MVC
//Core becomes framework-dependent


//✅ Clean Architecture – correct separation(your code)

//// Application
//public Product Add(Product product)
//{
//    Validate(product);
//    return _repository.Add(product);
//}

//// API
//if (!ModelState.IsValid)
//    return BadRequest();

//Why this fixes it
//UI handles HTTP
//Application handles rules
//No cross-contamination

//✅ Verification checklist
//[ ] Application layer has no MVC types
//[ ] Controllers contain no business rules