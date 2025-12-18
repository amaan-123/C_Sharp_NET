# Q) Help me study practically from the following file attached: Key(important) Goal: In 15 - 20 Dec 2025, complete: Design Patterns and Layered Architecture (Evaluation based on Mini Project demos) Extra(recommended) goal: Clean Architecture Today is 17 Dec 2025 and I have to start learning it by hands-on. Start with creating suitable plan

# A) Below is a **practical, hands-on study plan** aligned with your **evaluation window (15–20 Dec 2025)** and grounded **directly in the attached file**

The plan is **demo-oriented**, because your assessment is based on **mini project demonstrations**, not theory recall.

---

## 0. Guiding Principle (WHY before HOW)

Your evaluator wants to see **thinking maturity**, not pattern names.

So every step below answers:

* **Why** this structure exists
* **What problem it solves** (from the file’s “Problems Without Design Patterns”)
* **How** you applied it in code
* **What changed** compared to a naïve approach

Keep this explanation ready for demos.

---

## 1. Time-Boxed Plan (17–20 Dec)

### Today: **17 Dec (Foundation + Layered Architecture)**

Focus: **Layered Architecture only**
Outcome: **Working mini project (CRUD) with strict layer rules**

### 18 Dec: **Design Patterns inside Layered Architecture**

Focus: **Repository, Service, DTO, Dependency Injection**
Outcome: **Patterns strengthening the layered structure**

### 19 Dec: **Refactor to Clean Architecture (Optional but High-Impact)**

Focus: **Dependency Rule, Domain isolation**
Outcome: **Same app, better architecture**

### 20 Dec: **Demo Readiness**

Focus: **Explain trade-offs, diagrams, “why not direct DB access”**
Outcome: **Evaluator-ready narrative**

---

## 2. Hands-On Mini Project (Single Use Case)

Use **one consistent mini project** across all days.

**Recommended** (simple, evaluator-friendly):

> **Student Management / Library Books / Product Catalog**

CRUD is enough. Complexity is architectural, not functional.

---

## 3. Day 1 – Layered Architecture (17 Dec)

### WHY

From the file:

* UI → DAL coupling causes **bypassed business rules** and **duplication**
* Layered Architecture enforces **separation of concerns**

### WHAT you build

A **3-Layer application**:

```
Solution
│
├── Presentation (Web API)
│   └── Controllers
│
├── BusinessLogic
│   └── Services
│
└── DataAccess
    └── Repositories
```

### HOW (Hands-On Steps)

1. **Create solution + 3 projects**

   * `MyApp.Api`
   * `MyApp.BLL`
   * `MyApp.DAL`

2. **Enforce dependency rules**

   * API → BLL
   * BLL → DAL
   * DAL → nothing

3. **Implement one flow end-to-end**

   * Controller calls **Service**
   * Service validates rules
   * Service calls **Repository**
   * Repository does data access (in-memory or EF Core)

4. **Intentionally do NOT**

   * Access DbContext in Controller
   * Put validation in DAL

### Demo Talking Point

> “If tomorrow the database changes, only DAL changes.
> Business rules remain intact.”

---

## 4. Day 2 – Design Patterns inside Layered Architecture (18 Dec)

### WHY

From the file:

* Patterns reduce duplication
* Improve maintainability
* Provide a shared team vocabulary

### Patterns to Apply (Do NOT overdo)

#### 1. Repository Pattern (DAL)

**Problem solved:** DB logic scattered everywhere
**Action:**

* `IStudentRepository`
* `StudentRepository`

#### 2. Service Pattern (BLL)

**Problem solved:** Fat controllers
**Action:**

* `IStudentService`
* `StudentService`

#### 3. DTO Pattern (API ↔ BLL)

**Problem solved:** Entity leakage
**Action:**

* `CreateStudentDto`
* `StudentResponseDto`

#### 4. Dependency Injection

**Problem solved:** Tight coupling
**Action:**

* Inject interfaces, not concrete classes

### Demo Talking Point

> “Patterns are not features. They exist to control change.”

---

## 5. Day 3 – Clean Architecture Refactor (19 Dec, Extra)

### WHY

Layered Architecture still allows:

* Business logic depending on data access
* EF Core leaking into core rules

Clean Architecture **protects business rules**.

### WHAT changes (Same functionality)

```
Domain
│   └── Entities
│
Application
│   ├── Interfaces
│   └── UseCases
│
Infrastructure
│   └── Repositories (EF Core)
│
Presentation
    └── Controllers
```

### Key Hands-On Refactor

1. Move **entities** to Domain
2. Move **interfaces** to Application
3. Infrastructure implements interfaces
4. Presentation wires everything via DI

### Dependency Rule (Must explain)

> Dependencies always point inward
> Domain depends on nothing

---

## 6. Day 4 – Evaluation Readiness (20 Dec)

Prepare **short explanations**, not code dumps.

### Must-Answer Questions

1. **Why not UI → DAL directly?**
2. **Layered vs Clean Architecture**
3. **What breaks if business rules are in controllers?**
4. **Which layer changes if DB changes?**
5. **Where are interfaces defined and why?**

### Visual Aid

Draw:

* Layered flow arrows
* Clean Architecture dependency arrows

---

## 7. What NOT to Do (Common Evaluation Mistakes)

* Explaining 10 patterns superficially
* Using Clean Architecture without understanding Layered first
* Mixing EF Core in business logic
* Saying “best practice” without reasoning

---

## 8. Success Criteria (Self-Check)

You are ready if you can say:

> “This architecture exists because uncontrolled dependencies make change expensive.”

And **prove it in code**.

---

If you want, next step can be:

* A **day-wise coding checklist**
* A **demo script (what to say while presenting)**
* Or a **minimal reference implementation** to compare against yours

# Q) I have selected my one consistent mini-project to be: Product Catalog

Let's get started with day 1 work.

Your task: Think & then generate the plan for the 3-Layer application. Then give the steps to start: Create solution + 3 projects.

# A) Below is **Day-1–only**, strictly focused on **Layered Architecture** using your chosen **Product Catalog** mini-project

I will proceed in the order you asked:

1. **Think → generate the 3-Layer plan (WHY first)**
2. **Concrete project structure (WHAT)**
3. **Exact steps to create solution + 3 projects (HOW)**

No Clean Architecture yet. No patterns yet. Just **correct layering discipline**.

---

## 1. WHY a 3-Layer plan for Product Catalog

The Product Catalog use-case is ideal because it naturally exposes **all layering mistakes** beginners make:

* UI wants product lists
* Business wants rules (price > 0, stock ≥ 0, category valid)
* Data layer wants persistence (today in-memory / later EF Core)

Without layers:

* Controllers grow fat
* Validation is duplicated
* Database changes ripple everywhere

**Layered Architecture solves exactly this** by enforcing:

```
UI → Business Logic → Data Access
```

Each layer answers **one question only**:

| Layer    | Question it answers                          |
| -------- | -------------------------------------------- |
| UI (API) | How does the user talk to the system?        |
| BLL      | Is this operation allowed? What rules apply? |
| DAL      | How is data stored and retrieved?            |

---

## 2. WHAT you will build (Day-1 scope)

### Functional scope (keep it small)

Product Catalog with **basic CRUD**:

* Add Product
* Get All Products
* Get Product by Id
* Update Product
* Delete Product

No authentication. No paging. No EF Core yet (can be in-memory).

---

## 3. 3-Layer Design Plan (Conceptual)

### Layer responsibilities (non-negotiable)

#### 1️⃣ Presentation Layer (API)

**Purpose:** Interaction only

Contains:

* Controllers
* Request/response DTOs

Must NOT:

* Contain business rules
* Access repositories or DbContext

Talks to:

```
Controller → ProductService
```

---

#### 2️⃣ Business Logic Layer (BLL)

**Purpose:** Rules + orchestration

Contains:

* Services
* Business validations
* Application flow decisions

Examples:

* Product price must be > 0
* Product name required
* Category must be valid

Must NOT:

* Know about HTTP
* Know about database details

Talks to:

```
ProductService → ProductRepository
```

---

#### 3️⃣ Data Access Layer (DAL)

**Purpose:** Data storage mechanics

Contains:

* Repository classes
* Data source (in-memory list today)

Must NOT:

* Contain business rules
* Talk to controllers

---

## 4. High-Level Object Flow (Mental Model)

When user calls:

```
POST /api/products
```

Flow is **always**:

```
Controller
  ↓
ProductService
  ↓
ProductRepository
```

And response flows back up.

If you ever feel tempted to shortcut this — **that is the learning moment**.

---

## 5. Solution & Project Structure (WHAT to create)

### Solution name

```
ProductCatalog
```

### Projects inside solution

```
ProductCatalog.sln
│
├── ProductCatalog.Api        (Presentation Layer)
├── ProductCatalog.BLL        (Business Logic Layer)
└── ProductCatalog.DAL        (Data Access Layer)
```

### Project reference rules (important)

| From | Can reference |
| ---- | ------------- |
| Api  | BLL           |
| BLL  | DAL           |
| DAL  | none          |

This enforces architecture **at compile time**, not by discipline alone.

---

## 6. HOW: Step-by-Step — Create Solution + 3 Projects

### Step 1: Create the solution

Using CLI (recommended for clarity):

```bash
dotnet new sln -n ProductCatalog
```

---

### Step 2: Create the Web API project (UI layer)

```bash
dotnet new webapi -n ProductCatalog.Api
```

Add it to solution:

```bash
dotnet sln add ProductCatalog.Api
```

---

### Step 3: Create Business Logic Layer project

Use a **Class Library**:

```bash
dotnet new classlib -n ProductCatalog.BLL
dotnet sln add ProductCatalog.BLL
```

---

### Step 4: Create Data Access Layer project

Also a **Class Library**:

```bash
dotnet new classlib -n ProductCatalog.DAL
dotnet sln add ProductCatalog.DAL
```

---

### Step 5: Add project references (this is architecture enforcement)

```bash
dotnet add ProductCatalog.Api reference ProductCatalog.BLL
dotnet add ProductCatalog.BLL reference ProductCatalog.DAL
```

❌ Do **NOT** add DAL reference to API.

---

## 7. Sanity Check (Very Important)

Open the solution and verify:

* API **cannot** see repositories
* DAL **cannot** see controllers
* Only BLL sits in between

If this is true, **Day-1 architecture is correct**.

---

## 8. What you should NOT implement yet

Deliberately postpone:

* Repository pattern abstraction
* DTO mapping libraries
* EF Core
* Clean Architecture

Today is about **structure discipline**, not features.

---

## Next Step (after you confirm)

Once you confirm the solution & projects are created correctly, next we will:

1. Define **Product model placement**
2. Design **Service vs Repository contracts**
3. Implement **one complete vertical slice** (Add Product)

Say **“Proceed to Day-1 coding: Product flow”** when ready.

# Q) For step 3.1 Create Repository Interface, Project: ProductCatalog.DAL, Folder: Repositories, File: IProductRepository.cs, the line

`using ProductCatalog.BLL.Models;` gives error: "The type or namespace name 'BLL' does not exist in the namespace 'ProductCatalog' (are you missing an assembly reference?)"

# A) This error is **correct and expected**. It is not a mistake; it is a **layering lesson**

Let’s reason it through carefully.

---

## 1. WHY this error happens (root cause)

The DAL project is trying to use:

```csharp
using ProductCatalog.BLL.Models;
```

But:

* `ProductCatalog.DAL` **does not reference** `ProductCatalog.BLL`
* Therefore the compiler says: *“I don’t know what BLL is”*

This exposes a **design flaw in our initial plan**.

---

## 2. The real architectural issue (important learning)

In **Layered Architecture**, when **multiple layers need a shared model**, that model **must not belong to any single layer**.

Right now:

* BLL needs `Product`
* DAL needs `Product`

So placing `Product` inside **BLL** was **incorrect**.

If DAL depends on BLL just for models, then:

* DAL would indirectly depend on business logic
* That violates separation of concerns

---

## 3. Correct fix (industry-accepted)

### Introduce a **Shared / Core / Domain** project

This is **still Layered Architecture**, not Clean Architecture.

### New structure

```
ProductCatalog.sln
│
├── ProductCatalog.Api
├── ProductCatalog.BLL
├── ProductCatalog.DAL
└── ProductCatalog.Core   ← shared models
```

**Rule:**

* Core has **no dependencies**
* BLL and DAL can depend on Core
* API can depend on BLL (and Core indirectly)

---

## 4. HOW to fix step-by-step (do this now)

### Step 1: Create Core project

```bash
dotnet new classlib -n ProductCatalog.Core
dotnet sln add ProductCatalog.Core
```

---

### Step 2: Move Product model to Core

**Project:** `ProductCatalog.Core`
**Folder:** `Models`
**File:** `Product.cs`

```csharp
namespace ProductCatalog.Core.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Category { get; set; } = string.Empty;
}
```

---

### Step 3: Update project references

```bash
dotnet add ProductCatalog.BLL reference ProductCatalog.Core
dotnet add ProductCatalog.DAL reference ProductCatalog.Core
```

Do **not** add BLL ↔ DAL references here.

---

### Step 4: Fix using statements

#### In DAL (Repository)

```csharp
using ProductCatalog.Core.Models;
```

#### In BLL (Service)

```csharp
using ProductCatalog.Core.Models;
```

---

## 5. WHY this matters (evaluation gold)

You can now explain:

> “Shared business entities must live in a dependency-free core.
> Otherwise, layers become coupled through models.”

This is exactly the reasoning that **leads naturally to Clean Architecture** later.

---

## 6. Updated Layer Dependency Diagram

```
Api
 ↓
BLL
 ↓
DAL

BLL ─────→ Core ←───── DAL
```

Core sits **outside the flow**, shared but independent.

---

## 7. Important reassurance

You did **nothing wrong**.

This error is:

* Common
* Valuable
* A sign you are learning architecture correctly

---

## Next Step

Once you confirm:

* Core project added
* Product moved
* Build succeeds

We continue with:
**“Resume Day-1: Service + Controller wiring after Core fix”**

# Q) Resume Day-1: Service + Controller wiring after Core fix

# A) Below is the **continuation of Day-1**, resuming **Service + Controller wiring** after the **Core fix**

We proceed carefully, enforcing **Layered Architecture rules** at every step.

---

## 1. Re-establish the correct dependency picture (WHY)

After introducing **ProductCatalog.Core**, the dependency graph is now:

```
Api  →  BLL  →  DAL
          ↘
            Core
DAL  ─────────→ Core
```

Key rule:

* **Core depends on nothing**
* **BLL and DAL depend on Core**
* **API depends only on BLL**

If your solution matches this, you are architecturally correct.

---

## 2. Resume BLL – Product Service (Corrected)

### 2.1 Verify project references

Run once to be sure:

```bash
dotnet list ProductCatalog.BLL reference
```

You should see:

* `ProductCatalog.Core`
* `ProductCatalog.DAL`

---

### 2.2 Service Interface (BLL)

**Project:** `ProductCatalog.BLL`
**Folder:** `Services`
**File:** `IProductService.cs`

```csharp
using ProductCatalog.Core.Models;

namespace ProductCatalog.BLL.Services;

public interface IProductService
{
    IEnumerable<Product> GetAll();
    Product Add(Product product);
}
```

---

### 2.3 Service Implementation (BLL)

**File:** `ProductService.cs`

```csharp
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
        // Business rules live ONLY here
        if (string.IsNullOrWhiteSpace(product.Name))
            throw new ArgumentException("Product name is required");

        if (product.Price <= 0)
            throw new ArgumentException("Price must be greater than zero");

        if (product.Stock < 0)
            throw new ArgumentException("Stock cannot be negative");

        return _repository.Add(product);
    }
}
```

At this point:

* BLL has **rules**
* BLL has **no HTTP knowledge**
* BLL has **no data storage details**

---

## 3. Resume DAL – Repository (Corrected)

### 3.1 Interface

**Project:** `ProductCatalog.DAL`
**Folder:** `Repositories`
**File:** `IProductRepository.cs`

```csharp
using ProductCatalog.Core.Models;

namespace ProductCatalog.DAL.Repositories;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product? GetById(int id);
    Product Add(Product product);
}
```

---

### 3.2 In-Memory Repository Implementation

**File:** `ProductRepository.cs`

```csharp
using ProductCatalog.Core.Models;

namespace ProductCatalog.DAL.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();
    private int _nextId = 1;

    public IEnumerable<Product> GetAll()
    {
        return _products;
    }

    public Product? GetById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public Product Add(Product product)
    {
        product.Id = _nextId++;
        _products.Add(product);
        return product;
    }
}
```

DAL remains **logic-free**.

---

## 4. Resume API – Dependency Injection Wiring

### WHY

Dependency Injection **connects layers without coupling them**.

---

### 4.1 Program.cs

**Project:** `ProductCatalog.Api`

```csharp
using ProductCatalog.BLL.Services;
using ProductCatalog.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Layer wiring
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

app.MapControllers();
app.Run();
```

Important:

* API references **BLL**
* API does **not** reference Core or DAL directly in controllers

---

## 5. Resume API – Products Controller

### 5.1 Controller Implementation

**Folder:** `Controllers`
**File:** `ProductsController.cs`

```csharp
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.BLL.Services;
using ProductCatalog.Core.Models;

namespace ProductCatalog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }

    [HttpPost]
    public IActionResult Add(Product product)
    {
        try
        {
            var created = _service.Add(product);
            return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
```

Controller responsibility:

* HTTP mapping
* Error translation
* **No business rules**

---

## 6. Build & Run Check (Do This Now)

```bash
dotnet build
dotnet run --project ProductCatalog.Api
```

Test via Postman or curl:

### POST

```json
{
  "name": "Laptop",
  "price": 75000,
  "stock": 5,
  "category": "Electronics"
}
```

### GET

```
GET /api/products
```

---

## 7. Architecture Self-Audit (Critical)

Answer these **out loud**:

* Can I remove Web API and still test business rules? → Yes
* Can I swap in EF Core later? → Yes
* Does DAL know business rules? → No
* Does BLL know HTTP? → No

If all are “Yes/No” as above → **Day-1 objective achieved**.

---

## 8. What Day-1 Has Accomplished

You now have:

* Correct **3-Layer Architecture**
* Clear **responsibility boundaries**
* A working **vertical slice**
* A natural bridge toward **Design Patterns (Day-2)**

---

## Next Step (only when you’re ready)

Next we will:

* Add **Update + Delete**
* Introduce **DTOs** to protect Core models
* Deliberately break layering once — and fix it

Say:
**“Continue Day-1: Update/Delete + DTO separation”**

# Q) I have exactly the same code as you suggested and it build & runs perfectly

I use the `ProductCatalog.Api.http` file to send requests: first a POST(201 created with data displayed), then the GET. But the GET returns 200 OK with empty array [ ] as output. I debugged the code, but can't see the problem. Do you need any context before you tell me what could be the issue? Solution steps for this?
> Remind me to "Continue Day-1: Update/Delete + DTO separation" later.

# A) No extra context needed. This is a **classic Day-1 layered architecture issue**, and your observation is correct

---

## 1. WHY this happens (core reason)

Your code is correct, but your **object lifetime is wrong**.

### What you expect

* POST adds a product to an in-memory list
* GET returns the same list

### What is actually happening

* **Each HTTP request gets a new `ProductRepository` instance**
* Each instance has its own fresh `_products = new List<Product>()`
* So:

  * POST → adds product → request ends → object destroyed
  * GET → new repository → empty list

This is **not a bug in your logic**.
It is a **Dependency Injection lifetime behavior**.

---

## 2. WHERE the problem is (pinpointed)

In `Program.cs`:

```csharp
builder.Services.AddScoped<IProductRepository, ProductRepository>();
```

`AddScoped` means:

> “Create one instance **per HTTP request**”

That is perfect for EF Core, **but not for in-memory storage**.

---

## 3. WHY you are seeing it only now (important insight)

* With a real database → data persists → no issue
* With in-memory list → data lives only as long as the object

This is why **architecture learning often exposes lifecycle issues** early.

---

## 4. SOLUTION OPTIONS (choose intentionally)

### ✅ Option 1 (Correct for Day-1 learning): Use Singleton

Change repository registration to:

```csharp
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
```

Now:

* One repository instance
* One shared in-memory list
* POST → GET works as expected

This is the **right choice for learning layered flow**.

---

### ⚠️ Option 2 (Real-world): Use a database

Later, when you use EF Core:

```csharp
AddScoped<DbContext>()
```

is correct again.

But today, that would hide the learning.

---

## 5. WHY Service should NOT be Singleton

You might wonder:

> “Should ProductService also be Singleton?”

No.

* Services may depend on scoped resources later
* Singleton services + scoped dependencies = runtime errors

Keep this:

```csharp
builder.Services.AddScoped<IProductService, ProductService>();
```

---

## 6. Final corrected DI setup (Day-1)

```csharp
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
```

---

## 7. Learning you should explicitly state in evaluation

Say this clearly:

> “In-memory repositories require longer lifetimes.
> When using EF Core, persistence moves out of memory, so Scoped is correct again.”

This shows **architectural maturity**, not just coding.

---

## 8. Sanity test (do once)

1. Restart API
2. POST a product
3. GET products → you should see data

---

## Reminder

I’ll remind you later to:
**“Continue Day-1: Update/Delete + DTO separation”**

When you’re ready after the reminder, we continue cleanly.

# Q) Continue Day-1: Update/Delete + DTO separation

# A) Below is the **final Day-1 extension**: **Update/Delete + DTO separation**, still **pure Layered Architecture**

Goal: finish Day-1 with a **demo-ready, disciplined API**.

---

## 1. WHY these two additions matter

### Update/Delete

Without them, you have only a “happy path”.
Evaluators expect:

* full CRUD
* correct responsibility placement

### DTO separation

Right now your API exposes **Core models directly**.
That creates problems:

* UI tightly coupled to internal structure
* breaking changes ripple outward
* business entities become API contracts

DTOs fix this **without changing architecture**.

---

## 2. Update/Delete – start from the bottom (correct order)

### 2.1 DAL: extend repository contract

**Project:** `ProductCatalog.DAL`
**File:** `IProductRepository.cs`

```csharp
using ProductCatalog.Core.Models;

namespace ProductCatalog.DAL.Repositories;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product? GetById(int id);
    Product Add(Product product);
    bool Update(Product product);
    bool Delete(int id);
}
```

---

### 2.2 DAL: implement Update/Delete

**File:** `ProductRepository.cs`

```csharp
using ProductCatalog.Core.Models;

namespace ProductCatalog.DAL.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();
    private int _nextId = 1;

    public IEnumerable<Product> GetAll() => _products;

    public Product? GetById(int id)
        => _products.FirstOrDefault(p => p.Id == id);

    public Product Add(Product product)
    {
        product.Id = _nextId++;
        _products.Add(product);
        return product;
    }

    public bool Update(Product product)
    {
        var existing = GetById(product.Id);
        if (existing is null) return false;

        existing.Name = product.Name;
        existing.Price = product.Price;
        existing.Stock = product.Stock;
        existing.Category = product.Category;

        return true;
    }

    public bool Delete(int id)
    {
        var product = GetById(id);
        if (product is null) return false;

        _products.Remove(product);
        return true;
    }
}
```

DAL still has **zero business logic**.

---

## 3. BLL: extend service with rules

### 3.1 Service interface

**Project:** `ProductCatalog.BLL`
**File:** `IProductService.cs`

```csharp
using ProductCatalog.Core.Models;

namespace ProductCatalog.BLL.Services;

public interface IProductService
{
    IEnumerable<Product> GetAll();
    Product Add(Product product);
    bool Update(Product product);
    bool Delete(int id);
}
```

---

### 3.2 Service implementation

**File:** `ProductService.cs`

```csharp
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
        => _repository.GetAll();

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
```

Key point:

> **Validation logic is centralized and reusable.**

---

## 4. DTO separation (API only)

### WHY DTOs live in API

* DTOs are **communication contracts**
* They are **UI concerns**, not business concerns

---

### 4.1 Create DTOs

**Project:** `ProductCatalog.Api`
**Folder:** `DTOs`

#### CreateProductDto.cs

```csharp
namespace ProductCatalog.Api.DTOs;

public class CreateProductDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Category { get; set; } = string.Empty;
}
```

#### UpdateProductDto.cs

```csharp
namespace ProductCatalog.Api.DTOs;

public class UpdateProductDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Category { get; set; } = string.Empty;
}
```

---

## 5. Controller – now clean & correct

**Project:** `ProductCatalog.Api`
**File:** `ProductsController.cs`

```csharp
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Api.DTOs;
using ProductCatalog.BLL.Services;
using ProductCatalog.Core.Models;

namespace ProductCatalog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
        => Ok(_service.GetAll());

    [HttpPost]
    public IActionResult Add(CreateProductDto dto)
    {
        try
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock,
                Category = dto.Category
            };

            var created = _service.Add(product);
            return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateProductDto dto)
    {
        try
        {
            var product = new Product
            {
                Id = id,
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock,
                Category = dto.Category
            };

            var updated = _service.Update(product);
            return updated ? NoContent() : NotFound();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var deleted = _service.Delete(id);
            return deleted ? NoContent() : NotFound();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
```

---

## 6. Architecture checkpoint (say this in demo)

* DTOs protect Core models
* Controllers map HTTP ↔ business
* Services enforce rules
* Repositories handle persistence
* No layer skips another

---

## 7. Day-1 COMPLETE (what you now have)

You now have:

* Full CRUD
* Correct 3-layer architecture
* DTO separation
* In-memory persistence
* Demo-ready explanation

This is a **solid evaluation-passing baseline**.

---

## What comes next (Day-2)

Next session we will:

* Name & formalize **Design Patterns** you already used
* Introduce **Repository + Service patterns explicitly**
* Compare **Layered vs Clean Architecture using your own code**

When ready, say:
**“Start Day-2: Design Patterns inside Layered Architecture”**
