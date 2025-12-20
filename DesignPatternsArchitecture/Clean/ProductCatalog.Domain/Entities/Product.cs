namespace ProductCatalog.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Category { get; set; } = string.Empty;
}

////2) Entities and models tied to database concerns
////➡️ Clean advantage: Domain entities are framework-independent

////❌ Layered Architecture – common trap
//// Entity polluted with DB concerns
//public class Product
//{
//    public int Id { get; set; }

//    [Column("product_name")]
//    public string Name { get; set; }

//    [ForeignKey("Category")]
//    public int CategoryId { get; set; }
//}

////Problem
////    Entity is no longer a business concept
////    It is now a database schema artifact

////Fix:
////✅ Clean Architecture – correct way (above Domain)
//// Infrastructure
//modelBuilder.Entity<Product>()
//    .Property(p => p.Name)
//    .HasColumnName("product_name");
////Why this fixes it:
////    Domain models express business meaning only
////    Persistence rules live in Infrastructure

//## ✅ Verification checklist
//*[] Domain project has ** no EF Core attributes**
//*[] Domain project references ** no ORM packages** (e.g., EF Core: Microsoft.EntityFrameworkCore.SqlServer / Microsoft.EntityFrameworkCore.Sqlite(etc.), NHibernate, Dapper, or MongoDB)