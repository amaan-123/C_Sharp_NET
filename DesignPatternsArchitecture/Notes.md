## Evolution of Software Architecture

- To truly understand Clean Architecture, one must understand the history and the architectures that preceded it.
- Knowing why a design was created helps developers understand how to use it effectively.

## Traditional N-Layer Architecture

### Overview and Layers

- Common around 2008, typically consisting of three layers.
- **Presentation Layer**: Responsible only for the user interface (e.g., ASP.NET Webforms, MVC, Razor Pages).
- **Business Logic Layer (BLL)**: Contains business rules and logic.
- **Data Access Layer (DAL)**: Communicates with the database using tools like Entity Framework or Dapper.
- **Database**: The foundation of the system.

### Data-Centric Mindset

- N-layer applications were historically **data-centric**, meaning the database was designed first.
- The application's data models and entities were created based on the database tables.

![alt text](<Screenshot (965).png>)

### Logic Types in N-Layer

- **Domain Business Logic**: Rules specific to a domain entity (e.g., an employee's age must be between 18 and 67).
- **Application Business Logic**: Rules related to the application's operation (e.g., calculating salary on the 22nd of every month).

## Dependency Management

### Dependency Injection (DI)

- The **Presentation Layer** serves as the **startup project**, the initial point of execution where the DI container is instantiated.
- Each layer should ideally have extension methods to register its own services to avoid cluttering the presentation layer.

```csharp
// Example of an extension method for service registration in the persistence layer
public static IServiceCollection AddPersistenceServices(this IServiceCollection services) {
    services.AddScoped<IProductRepository, ProductRepository>();
    return services;
}
```

### Code vs. Framework Dependencies

- **Code Dependency**: When one project calls code from another.
- **Framework Dependency**: Required for service registration in the startup project; the presentation layer often needs references to all layers just to fill the DI container.

## Transition to Clean Architecture

### Key Enhancements to N-Layer

- Moving interfaces (e.g., `IRepository`) into the business logic layer to reverse the dependency direction.
- Placing entities in a central project accessible by both the data and business layers.
- Changing terminology: Data Access becomes **Persistence**, and Business Logic becomes the **Application** layer.

![alt text](<Screenshot (966).png>)

![alt text](<Screenshot (967).png>)

![alt text](<Screenshot (968).png>)

## Core Concepts of Clean Architecture

### Structure and Layers

- **Domain Layer**: The heart of the application containing entities and domain logic.
- **Application Layer**: Contains use cases and application-specific business logic.
- **Infrastructure Layer**: Includes the persistence layer, loggers, email senders, and other external concerns.
- **Presentation Layer**: The API or UI that exposes functionality to the world.

![alt text](<Screenshot (969).png>)

### The Domain-Centric Shift

- Unlike N-layer, the heart of Clean Architecture is the **Domain Model**, not the database.
- This approach is often paired with Domain-Driven Design (DDD) to emphasize the importance of the domain.

### Dependency Rules

- Outer layers can have dependencies on inner layers, but **inner layers must never depend on outer layers**.
- These rules apply specifically to code dependencies.
- The **Core** (Domain and Application layers) is wrapped to protect it from external infrastructure changes.

![alt text](<Screenshot (970).png>)

## Terminology Comparisons

- **Entities**: Also referred to as the Domain or Enterprise Business Rules.
- **Use Cases**: Also referred to as the Application layer or Application Business Rules.
- **Adapters**: The layer including controllers, presenters, and gateways that communicate with infrastructure.

![alt text](<Screenshot (971).png>)
