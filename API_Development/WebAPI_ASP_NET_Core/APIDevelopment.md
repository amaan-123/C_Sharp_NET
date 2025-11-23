# Build REST APIs in .NET 9 – Full Course for Beginners

<https://www.youtube.com/watch?v=38GNKtclDdE>

# Introduction to REST APIs

- This course teaches how to build REST APIs in .NET 9 using ASP.NET Core, covering CRUD operations and SQL Server database connection.
- The course is beginner-friendly and aims to avoid information overload.
- **Purpose of REST APIs:** They allow different applications (web app, mobile app, other software) to easily and efficiently communicate and access an application's data.
- **Communication Flow:** The front end of applications sends requests to the REST API, which processes them and sends back necessary data, instead of directly interacting with databases or business logic.
- **REST Definition:** Stands for **Representational State Transfer**.
- REST is a set of rules for how systems communicate over the web using HTTP methods (Get, Post, Put, Delete).
- **API Definition:** Stands for **Application Programming Interface**.

# Project Setup and Structure

- A new project is created in Visual Studio using the Web API template for .NET 9.

## Key Project Files

- **`Program.cs`:** The entry point of the program.
  - Here the app is built, services container is defined, and the HTTP request pipeline is set up.
  - Includes middleware for redirecting HTTP to HTTPS, authorizing requests, and mapping requests to the right controller.
- **`appsettings.json`:** The main configuration file.
  - Stores configurations for logging.
  - Stores database configurations, including the physical location of the database.
- **`Properties/launchSettings.json`:** Contains the application URL for the development environment.
- **`WeatherForecast` Class (Model):** A C# class that serves as the model for the REST API.
  - Defines the data structure: Date, Temperature (Celsius and Fahrenheit), and Summary.
- **Pre-built Controller:** A boilerplate controller containing an HTTP GET method.
  - This endpoint generates weather forecast data so that when a request is made, data is returned.

## Testing Endpoints

- **Swagger UI** is not included in this version of the project.
- **Method 1: The `.http` file**
  - Endpoints can be written in this generated file and tested directly using the "Send Request" button.
  - API calls in the `.http` file must be separated by three hashtags (`#`).
- **Method 2: Browser**
  - Use the application URL and append the controller name (e.g., `/WeatherForecast`).
- Other options like Postman are also available.

# Models and Controllers

## Models

- Models represent the data of the application (e.g., information about users).
- A model is a C# class. If data were stored in a database, the model would represent a table.
- **Example: `Book.cs` Model**

```csharp
public class Book
{
    public int ID { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public int YearPublished { get; set; }
}
```

## Controllers

- Controllers are the place where interactions with the REST API are specified (how to get, modify, or delete data).
- The route of a controller is typically accessible via the root URL + `/api/` + the controller name (e.g., `/api/books`).
- To test the API without a database initially, a static, private list of books is created inside the controller.

```csharp
private static List<Book> books = new List<Book> { /* book data */ };
```

- **Why `static`?** If the list is static, it is created only once when the controller is first instantiated. Changes (add, modify, delete) are saved across all upcoming HTTP requests. If the `static` keyword were removed, the list would be recreated with every new HTTP request, and all modifications would be lost.

# CRUD Operations with Static List

- HTTP methods are essential for handling different request types (get, modify, delete, submit data).
- All methods return an `ActionResult<T>` which includes data and a status code (e.g., 200 OK, 404 Not Found).

## 1. HTTP GET (Retrieve All Books)

- Used when users want to retrieve data from the API.
- Attribute: `[HttpGet]`.
- Return: `ActionResult<List<Book>>`.
- Response: Returns `Ok(books)` which sends a **200 OK** status code along with the data.

## 2. HTTP GET (Retrieve Specific Book by ID)

- Used when users request a specific resource.
- Attribute: `[HttpGet("{id}")]` (specifies the ID is expected in the URL).
- Logic: Search the `books` list using `FirstOrDefault` to find the book matching the requested ID.
- If the book is null, return `NotFound()` which sends a **404 Not Found** status code.
- If found, return `Ok(book)`.

## 3. HTTP POST (Create Resource)

- Used when a user sends data to the API (e.g., submitting a form).
- Attribute: `[HttpPost]`.
- Parameter: Expects the new book object (`Book newBook`).
- Validation: If `newBook` is null, return `BadRequest()` (**400 Bad Request**).
- Action: Adds the book to the list using the `.Add()` method.
- Response: Returns `CreatedAtAction`. This status type specifies that the resource was created and sends a **201 Created** status code.
- `CreatedAtAction` parameters include: the name of the GET method where the new resource can be accessed, the ID of the new book, and the created book object itself.

## 4. HTTP PUT (Update Resource)

- Used when a user tries to update existing data in the API.
- Attribute: `[HttpPut("{id}")]` (ID is required in the route).
- Return Type: `IActionResult` (since no object is returned, only a status code).
- Parameters: `int id` and `Book updatedBook`.
- Action: Find the existing book using the ID, then update its properties (ID, Title, Author, Year Published) with the properties from the `updatedBook`.
- Response: Returns `NoContent()` which returns a **204 No Content** status code.
- *Note:* Changes made using the static list are lost when the application is restarted.

## 5. HTTP DELETE (Delete Resource)

- Used when a client wants to delete resources from the API.
- Attribute: `[HttpDelete("{id}")]` (ID is required in the route).
- Return Type: `IActionResult`.
- Action: Find the book using the ID. If found, use the `.Remove()` method on the list.
- Response: Returns `NoContent()` (**204 No Content**).

***

## Topics Starting from Timestamp 34:29 (Connecting to SQL Server and Persistent Data)

The following notes focus on making the API data persistent by connecting to a SQL Server database using Entity Framework Core (EF Core).

## Connecting to SQL Server Database

- For real-world applications, data persistence is crucial, as static list data is lost when the app closes.
- **Prerequisites:** SQL Server database and SQL Server Management Studio (SSMS) must be installed. The Express version is recommended.

## Creating the Database

- The database is created using the **Server Explorer** in Visual Studio.
- Steps:
  - Go to `View` -> `Server Explorer`.
  - Right-click `Data Connections` and select `Create New SQL Server Database`.
  - The Server Name is taken from the SQL Server Management Studio connection.
  - Set `Encrypt` to `false` and click to trust the server certificate.
  - Name the database (e.g., `FirstAPI_Data`).
- After creation, copy the **Connection String** from the Properties window, which represents the physical location of the database.

## Storing the Connection String

- The connection string must be stored in the `appsettings.json` file.
- This location allows the project to know where the database is located.

```json
"ConnectionStrings": {
  "DefaultConnection": "/* copied connection string here */"
}
```

- The name `DefaultConnection` is used to reference the string later.

## Entity Framework Core (EF Core)

- EF Core is a framework/tool that enables interaction with the database using C# code.
- Configurations and data structure are specified in C# and then migrated to the database.

## Creating the Context Class

- The Context Class acts as the **bridge** between the C# code and the database.
- Standard practice is to store it in a new folder named `Data`.
- **Prerequisite:** Install the `Microsoft.EntityFrameworkCore` NuGet package.
- The class must inherit from `DBContext`.

```csharp
using Microsoft.EntityFrameworkCore;
using FirstAPI.Models;

namespace FirstAPI.Data
{
    public class FirstAPIContext : DbContext
    {
        // Constructor and DB Set instances go here
    }
}
```

- **Constructor:** The constructor is required to take default configurations, including `DBContextOptions<FirstAPIContext>`, which are passed to the base options.

- **DB Set Instance:** To map a model (like `Book`) to a database table, a `DbSet` instance must be specified inside the context. This allows access to the corresponding database table and performing operations on stored data.

```csharp
    public DbSet<Book> Books { get; set; }
```

## Declaring the Context Service (`Program.cs`)

- The Context Class must be declared in the services container using Dependency Injection.
- **Prerequisite:** Install the `Microsoft.EntityFrameworkCore.SqlServer` NuGet package.

```csharp
// Program.cs
using Microsoft.EntityFrameworkCore; // Required on top

// ... inside the code building the app ...

builder.Services.AddDbContext<FirstAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

- This code specifies that a SQL Server database is being used and locates the connection string named "DefaultConnection".

## Database Migrations

- A migration is a C# class that includes the schema of the database (data structure, model relationships).
- EF Core uses this information to determine how the database should look.
- **Prerequisite:** Install the `Microsoft.EntityFrameworkCore.Tools` NuGet package.

1. **Add Migration Command:**

    - Run in Package Manager Console:

    ```
    Add-Migration "BookModelAdded"
    ```

    - This command creates the migration class, defining that a table named `Books` with columns (ID, Title, Author, Year Published) will be created.

2. **Apply Migration Command:**

    - Run in Package Manager Console:

    ```
    Update-Database
    ```

    - This executes the changes, and the `Books` table is created in the SQL Server database.

## Seeding Data

- Data can be added manually or within the code using the `OnModelCreating` method override.
- This process stores the initial book data (which was previously in the static list) directly into the database.

```csharp
// Inside FirstAPIContext.cs

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Call base implementation to retain default configurations
    base.OnModelCreating(modelBuilder); 

    // Add data to the Book entity
    modelBuilder.Entity<Book>().HasData(
        new Book { ID = 1, Title = "Title 1", Author = "Author 1", YearPublished = 2000 },
        // ... all 5 books ...
    );
}
```

3. **Add Second Migration (for data):**

    ```
    Add-Migration "BookDataAdded"
    ```

4. **Apply Migration (for data):**

    ```
    Update-Database
    ```

- Verification in SSMS confirms the five books have been successfully migrated to the database table.

# ## Updating CRUD Operations to Use EF Core

- All controller methods must be modified to access the database via the Context class instead of the static list.
- **Dependency Injection:** The `FirstAPIContext` is injected into the controller's constructor.
- **Asynchronous Methods:** All methods accessing the database must be made **asynchronous** (`async` and `await`) to prevent the application thread from being blocked. The return type must be wrapped inside a `Task` keyword (e.g., `Task<ActionResult<List<Book>>>`).

## 1. HTTP GET (Retrieve All Books - Async)

- The method uses `_context.Books.ToListAsync()` to retrieve all books.

```csharp
[HttpGet]
public async Task<ActionResult<List<Book>>> GetBooks()
{
    return Ok(await _context.Books.ToListAsync());
}
```

## 2. HTTP GET (Retrieve Specific Book by ID - Async)

- The book is found using `_context.Books.FindAsync(id)`.

```csharp
[HttpGet("{id}")]
public async Task<ActionResult<Book>> GetBookById(int id)
{
    var book = await _context.Books.FindAsync(id);
    
    if (book == null)
    {
        return NotFound();
    }
    return Ok(book);
}
```

## 3. HTTP POST (Create Resource - Async)

- When performing an operation that changes the database (write operation), the changes must be explicitly saved using `SaveChangesAsync()`.

```csharp
[HttpPost]
public async Task<ActionResult<Book>> AddBook(Book newBook)
{
    if (newBook == null)
    {
        return BadRequest();
    }
    
    _context.Books.Add(newBook);
    await _context.SaveChangesAsync();
    
    // Returns 201 Created status code
    return CreatedAtAction(nameof(GetBookById), new { id = newBook.ID }, newBook);
}
```

- Posting a new book proves that data persists, as the newly added record appears in the database after the request.

## 4. HTTP PUT (Update Resource - Async)

- The existing book is found, properties are updated, and then changes are saved.

```csharp
[HttpPut("{id}")]
public async Task<IActionResult> UpdateBook(int id, Book updatedBook)
{
    var bookToUpdate = await _context.Books.FindAsync(id);

    if (bookToUpdate == null)
    {
        return NotFound();
    }
    
    bookToUpdate.ID = updatedBook.ID;
    bookToUpdate.Title = updatedBook.Title;
    bookToUpdate.Author = updatedBook.Author;
    bookToUpdate.YearPublished = updatedBook.YearPublished;

    await _context.SaveChangesAsync();
    
    // Returns 204 No Content status code
    return NoContent();
}
```

## 5. HTTP DELETE (Delete Resource - Async)

- The book is found using the ID, removed using `_context.Books.Remove()`, and then changes are saved.

```csharp
[HttpDelete("{id}")]
public async Task<IActionResult> DeleteBook(int id)
{
    var book = await _context.Books.FindAsync(id);

    if (book == null)
    {
        return NotFound();
    }

    _context.Books.Remove(book);
    await _context.SaveChangesAsync();
    
    // Returns 204 No Content status code
    return NoContent();
}
```

The successful implementation of these asynchronous methods ensures that the REST API now connects to the SQL Server database, and all CRUD operations result in persistent data changes.

***

**Analogy for Understanding Persistence:**

Think of the static list approach as writing notes on a whiteboard in a shared office; everyone sees the latest changes while the meeting is ongoing, but as soon as the office is locked up for the night (the application is closed), the whiteboard is wiped clean. Connecting to a SQL Server database, however, is like saving those notes to a cloud drive—the data is stored permanently, accessible across restarts, and guaranteed to persist for future use. Entity Framework Core acts as the librarian, managing the flow of information between your application's C# code and that cloud drive.
