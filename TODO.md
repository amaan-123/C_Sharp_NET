# 🌐 Full-Stack Developer Learning Tracker

Markdown tracker with interactive checkboxes for revision and to-do items, and **three simple understanding level tags**.

- Avoid theory overload: limit new info per session to prevent cognitive overload.  
- Follow the experiential cycle: do → observe results → decide what to change → experiment again.  
- Balance learning: pair every theory chunk with immediate practice.  
- Slow down to speed up: prioritize gradual learning so skills become habits.  
- Automate habits: practice until skills use fewer cognitive resources before adding new theory.  
- Use the 5:1 rule: aim for ~5 hours practice per 1 hour theory; adjust by how fast you form habits.

## Immediate TO-DO's

- Architecture:
  <!-- - What resource to follow? -->
  - Program.cs: for service(or for repository?): AddScoped, Singleton, Transient
  - Use EF Core in both (keep In-Memory)
  - revise plan.md pre-eval
  <!-- - Clean Architecture:
  - Layered Architecture:
    - is core an industry practice? -->
- Design Patterns: Learn
- MVC
  - Assignment from Masterclass
    - .cshtml.cs & .cs files when using identity
    - Relationship between models (foreignkey, include(), eager loading...)
      - When deleting author selected:
        - if books present, redirect to view where user can delete them first
    <!-- - Tests & Logging (ILogger)
      - Add simple unit tests for controller actions (mock DbContext with in-memory provider).
      - Add ILogger<T> to controllers and log events (read/updates/errors).
        - _logger in which index method based on that
      - if dependency injection correct, but not registered as services in program.cs, auto-registered on  WebApplication.CreateBuilder() line.
      - log levels: by default how many?
        - loginformation("accessed??") in CMD console
        - logerror
        - or write to file/database -->
    - Development & Production: appsettings.___.json & launchsettings.json
    - Combining multiple Models to show in one view
  - Masterclass notes, focussing on completing DI, Services, etc that was common
  - Put/Delete vs Post in MVC Action methods controllers. In WebAPI, there is Kestrel also.
  - Read on IIS
  <!-- - ✔ What you should focus on next
    - Understanding policies: Build rules like "User must be Admin OR MovieOwner".(How to enforce policy-based authorization (more powerful than roles))
    - Extending user profile: Add custom fields like FirstName, or link Movies to Users.
    - Building an Admin dashboard: Manage users, roles, and permissions.
    - Email confirmation & password reset: Essential in real-world apps.
    - Moving to ViewModels for Identity: Learn how Identity UI logic is structured. -->
  <!-- ~~- Re-read once the MS Learn on Friday Night~~
  - ~~MS learn hands-on, then~~
    ~~- Don't even show CRUD buttons to non-admin.~~ -->

- ReactJS
  <!-- - ~~class Component vs functional Component. Why do we use functional component?~~
  ~~- what are & why we use hooks?~~ -->
  - w3 schools only - read on hooks
    - Asg 2a - useEffect why?
    - useRef
    - useContext
    - avoid prop drilling - ContextApi
    - react router
  - Asg 2b
    - try editing/adding student on same page
  - Asg 1:
    - try map instead of forEach
    - task 4 variants
          - proptype(less imp)  
  - post-list-typicode
    - limiting number of posts per page(say 10 instead of 100)
- WebAPI
  - Make & read notes
    - 1st Priority: Complete assignments
    - Why we need EF Core?
      - TODO of SLCM POST
      <!-- - Dependency Injection
      - Logging -->
      <!-- - Exception Handling, Validation ([ApiController]) -->
      - Program.cs: for service(or for repository?): AddScoped, Singleton, Transient
      - ~~SLCM EF Core Extension: Courses~~, Enrollment
    - If free time:
      - Contacts Assignment
      - ProductAPI from its README.md
  <!-- - Make the .NET CLI run the ContosoPizza project <https://learn.microsoft.com/en-us/training/modules/build-web-api-aspnet-core/3-exercise-create-web-api> -->
  <!-- - Interesting info for project: ASP.NET Core provides a built-in user database with support for multi-factor authentication and external authentication with Google, X, and more. -->
  
- C#
  - complete masterclass.md assignments by self
    - 1. Adding items to cart at once, instead of one-by-one - dictionary?
      - Precedence of operators(* & /)?
  - BankingApp:
    <!-- - implement intefaces by self
      - why use?
      - what needs to be modified in code that has already been written? -->
    - what minimalistic changes to operate BankApp from a user-focused console menu
    - password authentication/ etc?
  - Downloads/sort.txt(List <---> ArrayList)
  - Regular Expressions(Regex pattern)/ Pattern Matching/Delegates/Struct & Record
  <!-- - later after methods & in debug: watch window, debug key equivalents of bar; call stack useful? -->
<!-- - Browser Reading list (.NET, Azure OpenAI service, API Key safety, Postman) -->
<!-- What is WSL? & What is the one that shows in VS Code? -->

> ✅ Checkbox States
>
>- `[x]` → Completed
>- `[ ]` → To-do / Not yet started
>- `[-]` → Need revision / In progress
>
> 🏷️ Understanding Level Tags
>
>| Tag           | Meaning                                                               |
>| ------------- | --------------------------------------------------------------------- |
>| 🔴 `Basic`    | You understand the topic and can follow along with examples.          |
>| 🟡 `Working`  | You can apply the concept in practice, with minor reference.          |
>| 🟢 `Mastered` | You can explain, apply, and debug the topic confidently without help. |

---

## 1. DevTooling (VS 2022 IDE, VS Code +CLI)

## 2. C# (using Visual Studio 2022)

- [x] 🟢 Hello World, variables, data types
- [x] 🟢 Control structures (if, loops)
- [x] 🟢 Methods and parameters
- [x] 🟢 Classes and Objects
- [x] 🟡 Properties and constructors
- [x] 🟡 Namespaces
- [x] 🟡 Interfaces and inheritance
- [x] 🟡 Exception handling
- [x] 🟡 Collections (List, Dictionary)
- [ ] 🔴 File I/O
- [x] 🟡 LINQ
- [ ] 🔴 Consuming APIs with `HttpClient`
- [x] 🟡 Building a Web API with ASP.NET Core
- [x] 🟡 Routing, controllers, attributes
- [ ] 🔴 Model-View-Controller pattern
- [x] 🟡 Entity Framework Core basics
- [x] 🟡 Swagger integration

---

## 🚧 Future (Cross-cutting / DevOps / Next Steps)

- [-] 🔴 SQL basics: SELECT, INSERT, UPDATE, DELETE
- [-] 🔴 Relational database design (ERDs, normalization)
- [ ] 🔴 Docker and container basics
- [ ] 🔴 DevOps: CI/CD intro
- [ ] 🔴 Cloud basics (e.g., deploying to Azure/AWS)
- [ ] 🔴 Versioning APIs
- [ ] 🔴 Authentication (JWT, OAuth)
- [ ] 🔴 Clean architecture / layered architecture

## 🚀 Real-World Application Essentials

- [x] 🔴 JavaScript Execution Context (Call Stack, Memory Heap)
- [ ] 🔴 JavaScript Prototypal Inheritance
- [ ] 🔴 Design Patterns (Singleton, Factory, Observer)
- [ ] 🔴 SOLID Principles
- [ ] 🔴 Testing Strategies (Unit, Integration, E2E)
- [ ] 🔴 Performance Optimization Techniques
- [ ] 🔴 Security Best Practices (e.g., preventing XSS, SQL Injection)

## 🎯 Interview Hot Topics

- [ ] 🔴 Data Structures and Algorithms (Arrays, Linked Lists, Trees, Sorting, Searching)
- [ ] 🔴 Time Complexity (Big O notation)
- [x] 🔴 Common JavaScript Questions (Closures, `this` keyword, Event Loop)
- [ ] 🔴 System Design Basics (Load Balancing, Caching)
- [x] 🟢 Behavioral Questions (STAR method)

---
