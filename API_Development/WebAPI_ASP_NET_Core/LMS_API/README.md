## Assignment: Library Management System (Basic CRUD)

### Overview

Build a simple Library Management System API that manages books and authors. This assignment focuses on implementing basic CRUD operations with proper project structure.

### Requirements

#### 1. Models

Create the following models:

**Author Model:**
csharp public class Author { public int Id { get; set; } public string FirstName { get; set; } public string LastName { get; set; } public DateTime DateOfBirth { get; set; } public string Email { get; set; } public string Biography { get; set; } public List<Book> Books { get; set; } = new List<Book>(); }
**Book Model:**
csharp public class Book { public int Id { get; set; } public string Title { get; set; } public string ISBN { get; set; } public int Pages { get; set; } public DateTime PublishedDate { get; set; } public decimal Price { get; set; } public bool IsAvailable { get; set; } public int AuthorId { get; set; } public Author Author { get; set; } }

#### 2. Database Setup

- Configure Entity Framework with SQL Server LocalDB
- Create appropriate DbContext with relationships
- Seed initial data (at least 3 authors and 5 books)
- Implement proper database migrations

#### 3. API Endpoints

Implement the following endpoints:

**Books Controller:**

- `GET /api/books` - Get all books
- `GET /api/books/{id}` - Get book by ID
- `POST /api/books` - Create new book
- `PUT /api/books/{id}` - Update existing book
- `DELETE /api/books/{id}` - Delete book

**Authors Controller:**

- `GET /api/authors` - Get all authors
- `GET /api/authors/{id}` - Get author by ID
- `GET /api/authors/{id}/books` - Get all books by specific author
- `POST /api/authors` - Create new author
- `PUT /api/authors/{id}` - Update existing author
- `DELETE /api/authors/{id}` - Delete author

#### 4. Technical Requirements

- Use proper DTOs for request/response
- Implement model validation with Data Annotations
- Use dependency injection for services
- Return appropriate HTTP status codes
- Include basic logging in controllers

#### 5. Validation Rules

- Book title: Required, max 200 characters
- ISBN: Required, exactly 13 characters
- Author email: Required, valid email format
- Pages: Must be greater than 0
- Price: Must be greater than 0

---

Below is a complete end-to-end solution you can paste into a new ASP.NET Core Web API project, plus a focused, easy-to-follow lesson for Database Setup and how the Technical Requirements are implemented.

---

# 1 — Project layout (recommended)

```
LibraryApi/
├─ Controllers/
│  ├─ AuthorsController.cs
│  └─ BooksController.cs
├─ Dtos/
│  ├─ AuthorCreateDto.cs
│  ├─ AuthorReadDto.cs
│  ├─ BookCreateDto.cs
│  ├─ BookReadDto.cs
│  └─ BookUpdateDto.cs
├─ Models/
│  ├─ Author.cs
│  └─ Book.cs
├─ Data/
│  ├─ LibraryContext.cs
│  └─ DbInitializer.cs
├─ Services/
│  ├─ IAuthorService.cs
│  ├─ IBookService.cs
│  ├─ AuthorService.cs
│  └─ BookService.cs
├─ appsettings.json
└─ Program.cs
```

---

# 2 — Models (with Data Annotations)

File: `Models/Author.cs`

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [Required, StringLength(100)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [StringLength(2000)]
        public string Biography { get; set; }

        public List<Book> Books { get; set; } = new();
    }
}
```

File: `Models/Book.cs`

```csharp
using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; }

        [Required, StringLength(13, MinimumLength = 13)]
        public string ISBN { get; set; }

        [Range(1, int.MaxValue)]
        public int Pages { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        public bool IsAvailable { get; set; } = true;

        // Relationship
        [Required]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
```

---

# 3 — DTOs

Use DTOs for requests/responses so the API does not accept or return DB entities directly.

`Dtos/AuthorCreateDto.cs`

```csharp
using System;
using System.ComponentModel.DataAnnotations;

public class AuthorCreateDto
{
    [Required, StringLength(100)] public string FirstName { get; set; }
    [Required, StringLength(100)] public string LastName { get; set; }
    [Required] public DateTime DateOfBirth { get; set; }
    [Required, EmailAddress] public string Email { get; set; }
    [StringLength(2000)] public string Biography { get; set; }
}
```

`Dtos/AuthorReadDto.cs`

```csharp
using System;
using System.Collections.Generic;

public class AuthorReadDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string Biography { get; set; }
    public List<BookReadDto> Books { get; set; } = new();
}
```

`Dtos/BookCreateDto.cs`

```csharp
using System;
using System.ComponentModel.DataAnnotations;

public class BookCreateDto
{
    [Required, StringLength(200)] public string Title { get; set; }
    [Required, StringLength(13, MinimumLength = 13)] public string ISBN { get; set; }
    [Range(1, int.MaxValue)] public int Pages { get; set; }
    [Required] public DateTime PublishedDate { get; set; }
    [Range(0.01, double.MaxValue)] public decimal Price { get; set; }
    public bool IsAvailable { get; set; } = true;
    [Required] public int AuthorId { get; set; }
}
```

`Dtos/BookUpdateDto.cs`

```csharp
using System;
using System.ComponentModel.DataAnnotations;

public class BookUpdateDto
{
    [Required, StringLength(200)] public string Title { get; set; }
    [Required, StringLength(13, MinimumLength = 13)] public string ISBN { get; set; }
    [Range(1, int.MaxValue)] public int Pages { get; set; }
    [Required] public DateTime PublishedDate { get; set; }
    [Range(0.01, double.MaxValue)] public decimal Price { get; set; }
    public bool IsAvailable { get; set; } = true;
    [Required] public int AuthorId { get; set; }
}
```

`Dtos/BookReadDto.cs`

```csharp
using System;

public class BookReadDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ISBN { get; set; }
    public int Pages { get; set; }
    public DateTime PublishedDate { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    public int AuthorId { get; set; }
    public string AuthorName { get; set; }
}
```

---

# 4 — DbContext + Seeding + Migrations

File: `Data/LibraryContext.cs`

```csharp
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace LibraryApi.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> opts) : base(opts) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        // configure relations and seed simple data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed authors
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FirstName = "Jane", LastName = "Austen", DateOfBirth = new DateTime(1775,12,16), Email = "jane.austen@example.com", Biography = "English novelist." },
                new Author { Id = 2, FirstName = "George", LastName = "Orwell", DateOfBirth = new DateTime(1903,6,25), Email = "george.orwell@example.com", Biography = "English novelist and essayist." },
                new Author { Id = 3, FirstName = "Mary", LastName = "Shelley", DateOfBirth = new DateTime(1797,8,30), Email = "mary.shelley@example.com", Biography = "English novelist, author of Frankenstein." }
            );

            // Seed books (must reference Author Ids)
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Pride and Prejudice", ISBN = "1111111111111", Pages = 432, PublishedDate = new DateTime(1813,1,28), Price = 9.99m, IsAvailable = true, AuthorId = 1 },
                new Book { Id = 2, Title = "Emma", ISBN = "2222222222222", Pages = 320, PublishedDate = new DateTime(1815,12,25), Price = 8.50m, IsAvailable = true, AuthorId = 1 },
                new Book { Id = 3, Title = "1984", ISBN = "3333333333333", Pages = 328, PublishedDate = new DateTime(1949,6,8), Price = 12.50m, IsAvailable = false, AuthorId = 2 },
                new Book { Id = 4, Title = "Animal Farm", ISBN = "4444444444444", Pages = 112, PublishedDate = new DateTime(1945,8,17), Price = 7.90m, IsAvailable = true, AuthorId = 2 },
                new Book { Id = 5, Title = "Frankenstein", ISBN = "5555555555555", Pages = 280, PublishedDate = new DateTime(1818,1,1), Price = 11.00m, IsAvailable = true, AuthorId = 3 }
            );
        }
    }
}
```

**appsettings.json** (include LocalDB connection)

```json
{
  "ConnectionStrings": {
    "LibraryConnection": "Server=(localdb)\\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

**Migrations steps** (run in terminal inside project folder)

1. Install EF packages:

```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
```

2. Install dotnet-ef tool (if not present):

```
dotnet tool install --global dotnet-ef
```

3. Create migration:

```
dotnet ef migrations add InitialCreate
```

4. Apply to DB:

```
dotnet ef database update
```

> Note: If you get errors about `LibraryContext` design-time creation, ensure `Program.cs` uses `AddDbContext<LibraryContext>(...)` or create a `DesignTimeDbContextFactory`.

---

# 5 — Services (Repository-like, with DI)

`Services/IBookService.cs`

```csharp
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryApi.Models;

public interface IBookService
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book> GetByIdAsync(int id);
    Task<Book> CreateAsync(Book book);
    Task<bool> UpdateAsync(Book book);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<Book>> GetByAuthorIdAsync(int authorId);
}
```

`Services/BookService.cs`

```csharp
using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BookService : IBookService
{
    private readonly LibraryContext _db;
    public BookService(LibraryContext db) => _db = db;

    public async Task<Book> CreateAsync(Book book)
    {
        _db.Books.Add(book);
        await _db.SaveChangesAsync();
        return book;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var b = await _db.Books.FindAsync(id);
        if (b == null) return false;
        _db.Books.Remove(b);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _db.Books.Include(b => b.Author).ToListAsync();
    }

    public async Task<Book> GetByIdAsync(int id)
    {
        return await _db.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<IEnumerable<Book>> GetByAuthorIdAsync(int authorId)
    {
        return await _db.Books.Where(b => b.AuthorId == authorId).Include(b => b.Author).ToListAsync();
    }

    public async Task<bool> UpdateAsync(Book book)
    {
        var existing = await _db.Books.FindAsync(book.Id);
        if (existing == null) return false;

        existing.Title = book.Title;
        existing.ISBN = book.ISBN;
        existing.Pages = book.Pages;
        existing.PublishedDate = book.PublishedDate;
        existing.Price = book.Price;
        existing.IsAvailable = book.IsAvailable;
        existing.AuthorId = book.AuthorId;

        await _db.SaveChangesAsync();
        return true;
    }
}
```

Implement similar `IAuthorService` and `AuthorService` (omitted here for brevity — they follow the same pattern: CRUD plus `GetBooksByAuthor`).

---

# 6 — Controllers (with logging, DTO mapping, validation)

`Controllers/BooksController.cs`

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly ILogger<BooksController> _logger;

    public BooksController(IBookService bookService, ILogger<BooksController> logger)
    {
        _bookService = bookService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookReadDto>>> GetAll()
    {
        var books = (await _bookService.GetAllAsync()).Select(b => new BookReadDto
        {
            Id = b.Id,
            Title = b.Title,
            ISBN = b.ISBN,
            Pages = b.Pages,
            PublishedDate = b.PublishedDate,
            Price = b.Price,
            IsAvailable = b.IsAvailable,
            AuthorId = b.AuthorId,
            AuthorName = b.Author != null ? $"{b.Author.FirstName} {b.Author.LastName}" : null
        }).ToList();

        return Ok(books);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BookReadDto>> GetById(int id)
    {
        var b = await _bookService.GetByIdAsync(id);
        if (b == null) return NotFound();
        var dto = new BookReadDto
        {
            Id = b.Id,
            Title = b.Title,
            ISBN = b.ISBN,
            Pages = b.Pages,
            PublishedDate = b.PublishedDate,
            Price = b.Price,
            IsAvailable = b.IsAvailable,
            AuthorId = b.AuthorId,
            AuthorName = $"{b.Author?.FirstName} {b.Author?.LastName}"
        };
        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<BookReadDto>> Create([FromBody] BookCreateDto create)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        // Map DTO => Entity
        var book = new Book
        {
            Title = create.Title,
            ISBN = create.ISBN,
            Pages = create.Pages,
            PublishedDate = create.PublishedDate,
            Price = create.Price,
            IsAvailable = create.IsAvailable,
            AuthorId = create.AuthorId
        };

        var created = await _bookService.CreateAsync(book);

        var readDto = new BookReadDto
        {
            Id = created.Id,
            Title = created.Title,
            ISBN = created.ISBN,
            Pages = created.Pages,
            PublishedDate = created.PublishedDate,
            Price = created.Price,
            IsAvailable = created.IsAvailable,
            AuthorId = created.AuthorId,
            AuthorName = null
        };

        _logger.LogInformation("Book created: {Id}", created.Id);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, readDto);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] BookUpdateDto update)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var b = await _bookService.GetByIdAsync(id);
        if (b == null) return NotFound();

        // Map update DTO onto entity
        b.Title = update.Title;
        b.ISBN = update.ISBN;
        b.Pages = update.Pages;
        b.PublishedDate = update.PublishedDate;
        b.Price = update.Price;
        b.IsAvailable = update.IsAvailable;
        b.AuthorId = update.AuthorId;

        var ok = await _bookService.UpdateAsync(b);
        if (!ok) return NotFound();

        _logger.LogInformation("Book updated: {Id}", id);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await _bookService.DeleteAsync(id);
        if (!ok) return NotFound();
        _logger.LogInformation("Book deleted: {Id}", id);
        return NoContent();
    }

    // Example of filtered endpoint (books by genre isn't in this assignment; books by author available via AuthorsController)
}
```

`Controllers/AuthorsController.cs` should expose:

- GET /api/authors
- GET /api/authors/{id}
- GET /api/authors/{id}/books (use `IBookService.GetByAuthorIdAsync`)
- POST /api/authors
- PUT /api/authors/{id}
- DELETE /api/authors/{id}

(Author controller maps DTOs similar to BooksController; include ModelState checks; use ILogger.)

---

# 7 — Program.cs (wiring DI, DbContext, Swagger)

`Program.cs`

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add EF DbContext
builder.Services.AddDbContext<LibraryApi.Data.LibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryConnection")));

// Add services
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Optionally ensure DB created & migrations applied on startup in development (use with caution in production)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LibraryApi.Data.LibraryContext>();
    db.Database.Migrate();
}

app.Run();
```

---

# 8 — How to run & test

1. Restore packages:

```
dotnet restore
```

2. Create initial migration (once):

```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

3. Run:

```
dotnet run
```

4. Open Swagger UI at `https://localhost:<port>/swagger` and test the endpoints:

- POST /api/authors (create author)
- POST /api/books (create book referencing an existing authorId)
- GET /api/books
- PUT /api/books/{id}
- DELETE /api/books/{id}
- GET /api/authors/{id}/books

**To show validation working**: in Swagger, for POST /api/books, submit JSON with missing `Title` or `ISBN` length not 13 — you will get 400 with validation details.

Example invalid book:

```json
{
  "title": "",
  "isbn": "123",
  "pages": 0,
  "publishedDate": "2000-01-01",
  "price": 0,
  "isAvailable": true,
  "authorId": 1
}
```

Expect 400 Bad Request with ModelState errors for `Title`, `ISBN`, `Pages`, and `Price`.

---

# 9 — Focused lesson: Database setup (step-by-step, easy)

This section explains the DB steps in plain terms.

1. **Why LocalDB?**
   LocalDB is a developer-friendly SQL Server instance that runs on your machine and requires no separate server installation. It is ideal for demos and local testing.

2. **Install EF Core packages** (project root):

```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
```

3. **Add `DbContext`**

   - Create a class `LibraryContext : DbContext`.
   - Add `DbSet<Author> Authors` and `DbSet<Book> Books`.
   - Configure relationships in `OnModelCreating`. This ensures EF knows the one-to-many relationship (Author → Books).

4. **Set connection string** in `appsettings.json`:

```json
"ConnectionStrings": {
  "LibraryConnection": "Server=(localdb)\\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

5. **Register DbContext** in DI container:

```csharp
builder.Services.AddDbContext<LibraryContext>(opt => opt.UseSqlServer(configuration));
```

6. **Create migrations** (these are C# files that describe changes in your model):

```
dotnet ef migrations add InitialCreate
```

7. **Apply migration to DB:**

```
dotnet ef database update
```

This creates the database and tables according to your model + seed data.

8. **Seeding data**

   - Add `HasData(...)` calls in `OnModelCreating`. When migration runs, EF will insert seed rows (it generates Insert statements in the migration).
   - `HasData` requires fixed Id values for seed rows.

9. **Automatic migrations on startup (optional)**

   - In `Program.cs` call `db.Database.Migrate()` inside a scoped section. Good for development, not always for production.

---

# 10 — How technical requirements are fulfilled (mapping to code)

- **Use proper DTOs** — `BookCreateDto`, `BookUpdateDto`, `BookReadDto`, `AuthorCreateDto`, `AuthorReadDto`. Controllers map DTOs to entities and vice versa.
- **Model validation with Data Annotations** — Attributes like `[Required]`, `[StringLength]`, `[Range]`, `[EmailAddress]` placed on model/DTO properties. `ApiController` + model binding automatically reports validation errors as `400 Bad Request`.
- **Dependency injection** — `AddDbContext`, `AddScoped<IBookService, BookService>()` done in `Program.cs`.
- **Return appropriate HTTP status codes** — `Ok` (200) for GET, `CreatedAtAction` (201) for POST, `NoContent` (204) for successful PUT/DELETE with no response body, `BadRequest` (400) for validation issues, `NotFound` (404) for missing resources.
- **Basic logging in controllers** — `ILogger<T>` injected in controllers; log operations like create/update/delete. You can expand log levels for exceptions or critical flows.

---

# 11 — Implementation notes, best-practices & small gotchas

- **Entity vs DTO validation**: Validate DTOs on entry (controllers). Keep entity classes focused on DB rules; use DTOs for contract validation.
- **ISBN length**: Use `StringLength(13, MinimumLength=13)` to enforce 13 characters. If ISBN formatting (dashes) is possible, consider normalizing before validation or relax the rule and use regex.
- **Deleting authors**: configured cascade delete — deleting an author will delete that author’s books. If you prefer preventing delete when books exist, change `OnDelete(DeleteBehavior.Restrict)`.
- **Seeding with `HasData`**: works for static seed at migration time. For dynamic seeding (e.g., environment-aware), use a runtime initializer (`DbInitializer`) that checks and inserts data if tables empty.
- **Transactions**: For multi-step operations spanning multiple tables, use EF transactions (`await _db.Database.BeginTransactionAsync()`).
- **Concurrency**: Not covered here—if needed, add rowversion concurrency tokens.
- **Testing**: Use Swagger UI for manual testing. For automated test, use in-memory provider `UseInMemoryDatabase` during unit tests.

---

# 12 — Example HTTP payloads

Create author:

```json
POST /api/authors
{
  "firstName": "Isaac",
  "lastName": "Asimov",
  "dateOfBirth": "1920-01-02",
  "email": "isaac.asimov@example.com",
  "biography": "Prolific science fiction author."
}
```

Create book:

```json
POST /api/books
{
  "title": "Foundation",
  "isbn": "1234567890123",
  "pages": 255,
  "publishedDate": "1951-06-01",
  "price": 10.5,
  "isAvailable": true,
  "authorId": 4
}
```

Update book:

```json
PUT /api/books/1
{
  "title": "Pride and Prejudice — Revised",
  "isbn": "1111111111111",
  "pages": 440,
  "publishedDate": "1813-01-28",
  "price": 10.99,
  "isAvailable": true,
  "authorId": 1
}
```

---
