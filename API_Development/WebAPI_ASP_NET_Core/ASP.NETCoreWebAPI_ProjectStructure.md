# Typical ASP.NET Core Web API project structure — what goes where (brief)

```
YourProject/
├─ Controllers/
├─ Models/
├─ Dtos/
├─ Data/                (or Persistence)
├─ Repositories/        (or Infrastructure)
├─ Services/            (or Business)
├─ Mappings/            (AutoMapper profiles)
├─ Middleware/
├─ Validators/          (FluentValidation, etc.)
├─ Helpers/             (utility classes)
├─ Properties/          (launchSettings.json)
├─ appsettings.json
├─ Program.cs
└─ YourProject.csproj
```

## Controllers/

* File per resource (plural): `StudentsController.cs`, `ProductsController.cs`
* Contains: `[ApiController]`, `[Route(...)]`, action methods `[HttpGet|Post|Put|Delete]` that handle requests and return `ActionResult<T>` / `IActionResult`.
* **Not limited** to one — create one controller per logical resource or API surface.

## Models/

* Domain / entity classes that represent data (DB or business): `Student.cs`, `Course.cs`.
* Keep persistence-specific attributes here only if aligned with DB model (or use separate Persistence models).

## Dtos/

* Input/Output shapes for API: `CreateStudentDto.cs`, `UpdateStudentDto.cs`, `StudentResponseDto.cs`.
* Used for model-binding and for responses — prevents exposing internal models.

## Data/ (Persistence)

* `AppDbContext.cs` (EF Core `DbContext` with `DbSet<T>`).
* Migrations folder (when using EF).
* Database-related configuration and seed data.

## Repositories/ (or Infrastructure)

* Data access code (wrapping DbContext or in-memory lists): `IStudentRepository`, `StudentRepository`.
* CRUD methods: `GetAll()`, `GetById()`, `Create()`, `Update()`, `Delete()`.

## Services/ (Business logic)

* Application-level logic / rules / orchestration: `StudentService`.
* Calls repositories, enforces validation or business policies.
* Controllers call services (not repositories) in larger apps.

## Mappings/

* AutoMapper profiles or manual mappers: `StudentProfile.cs` that maps `Student ↔ StudentDto`.

## Middleware/

* Custom request/response middleware: `ErrorHandlingMiddleware`, `RequestLoggingMiddleware`.
* Registered in `Program.cs`.

## Validators/

* Validation rules for DTOs: `CreateStudentDtoValidator` (FluentValidation) or manual validation logic.

## Helpers/Utilities

* Small utilities, constants, extension methods: `PagingHelper`, `Extensions.cs`.

## Configuration files

* `appsettings.json` / `appsettings.Development.json` for config (connection strings, logging).
* `launchSettings.json` controls launch profiles and HTTPS ports.

## Program.cs / Startup

* Register services: `builder.Services.AddControllers()`, DB context, repositories, services, AutoMapper, Swagger.
* Configure middleware pipeline: `UseSwagger()`, `UseHttpsRedirection()`, `UseAuthorization()`, `MapControllers()`.
* Single place for composition root.

## Tests/ (separate test project)

* Unit tests and integration tests: `YourProject.Tests/` with controller/service/repository tests and test fixtures.

---

# Naming & conventions (short)

* Controller name → `XyzController` → route default `[controller]` becomes `/xyz`.
* DTOs in `Dtos/<Entity>/` folder.
* Interfaces prefixed with `I` (`IStudentRepository`, `IStudentService`).
* Keep controllers thin: orchestrate services; keep business logic in services.

---

# Direct answers

* **Can you have only one controller?** No. Real projects have many controllers (one per resource or feature).
* **Where to put specific code?** Put request handling in Controllers, data/entity definitions in Models, API shapes in DTOs, data access in Repositories/Data, business rules in Services, DI and middleware setup in Program.cs.
