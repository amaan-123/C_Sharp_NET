# Project

## **Student Management Web API**

(Perfect match for your current skills and EF Core learning path)

A realistic API where you manage:

* Students
* Courses (optional for later)
* Enrollments (optional for EF Core later)

For now, you’ll build only **Student CRUD** using:

* Controllers
* Models
* DTOs
* Repository (in-memory list)
* Swagger testing

Later, you can extend it with EF Core.

### Why this project?

* Uses all CRUD operations.
* Includes controllers, DTOs, models, validation.
* Very easy to extend when you learn EF Core (simply replace List<> with DbContext).
* Matches common interview and real-world API patterns.
* Time-friendly: core CRUD takes **3–4 hours**.

---

# Core Features to Build (1–2 days)

### **1. Models**

```
Student
    Id
    Name
    Email
    Phone
    Age (optional)
```

### **2. DTOs**

* CreateStudentDto
* UpdateStudentDto
* StudentResponseDto

### **3. Controller**

`StudentController` with:

| HTTP Verb             | Action         | Purpose         |
| --------------------- | -------------- | --------------- |
| GET /students         | GetAllStudents | Retrieve all    |
| GET /students/{id}    | GetStudentById | Retrieve one    |
| POST /students        | CreateStudent  | Add new         |
| PUT /students/{id}    | UpdateStudent  | Modify existing |
| DELETE /students/{id} | DeleteStudent  | Remove          |

### **4. Repository (in-memory)**

A static List<Student> so you don’t need EF Core now.

---

# What exactly will you practice?

### **1. Routing**

* `[Route("api/[controller]")]`
* `[HttpGet]`, `[HttpPost]`, `[HttpPut]`, `[HttpDelete]`
* Route constraints like `{id:int}`

### **2. DTO Usage**

* Accept CreateStudentDto in POST
* Accept UpdateStudentDto in PUT
* Return StudentResponseDto

### **3. Response Methods**

* Ok()
* NotFound()
* BadRequest()
* CreatedAtAction()
* NoContent()

### **4. Basic Validation**

* Check if student exists
* Validate Email format (optional)

### **5. Testing in Swagger**

Use the built-in UI to test all endpoints.

---

# Optional Add-Ons (for later in the week or after EF Core)

When learning EF Core, replace your List<> with:

* A DbContext
* A Students table
* Real database CRUD

Then expand project:

### Add Courses

```
Course
    Id
    Title
    Credits
```

### Add Enrollments (link table)

```
Enrollment
    Id
    StudentId
    CourseId
    Grade
```

This turns it into a **real-world mini SLCM system**, which fits your learning journey perfectly.

---

# Resource: Workalong Guide

Use this free, high-quality tutorial (covers exactly what I listed):

### **Microsoft Learn – Create a Web API with ASP.NET Core**

(Hands-on, short, focused, official)
Search: *"Create a web API with ASP.NET Core - Microsoft Learn"*

It walks you through a Todo API:

* Controllers
* CRUD
* DTOs
* Swagger
* Routing

You can follow it step-by-step and replace Todo items with Students.

---

# Summary: Your Best Next Step

**Build a Student Management CRUD API**, starting with:

* Student model
* DTOs
* In-memory repository
* CRUD controller
* Swagger testing

Time: **4–6 hours**
Skill gain: **Massive**
Future-ready: Easily connect to EF Core later.

Below is a **clean, minimal, ready-to-code** folder structure plus **starter templates** for every file you need to build your Student Management CRUD API.

All files are short, practical, and easy to follow.
This structure mirrors real-world ASP.NET Core API projects.

---

# ✅ Folder Structure (exactly copy this)

```
YourProject/
│
├── Controllers/
│   └── StudentController.cs
│
├── Models/
│   └── Student.cs
│   └── SchoolRepository.cs
│
├── Dtos/
│   └── Students/
│       ├── CreateStudentDto.cs
│       ├── UpdateStudentDto.cs
│       └── StudentResponseDto.cs
│
├── Program.cs
└── YourProject.csproj
```

You can paste this **directly into your project**.

---

# ✅ File Templates (Copy-Paste Ready)

---

# 1. **Models/Student.cs**

```csharp
namespace YourProject.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
```

---

# 2. **Models/SchoolRepository.cs**

```csharp
using System.Collections.Generic;
using System.Linq;

namespace YourProject.Models
{
    public static class SchoolRepository
    {
        public static List<Student> Students = new()
        {
            new Student { Id = 1, Name = "Aisha", Email = "aisha@example.com", Phone = "1111111111" },
            new Student { Id = 2, Name = "Ravi", Email = "ravi@example.com", Phone = "2222222222" },
            new Student { Id = 3, Name = "Meena", Email = "meena@example.com", Phone = "3333333333" }
        };

        public static Student? GetById(int id) => Students.FirstOrDefault(s => s.Id == id);
    }
}
```

---

# 3. **Dtos/Students/CreateStudentDto.cs**

```csharp
namespace YourProject.Dtos.Students
{
    public class CreateStudentDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
```

---

# 4. **Dtos/Students/UpdateStudentDto.cs**

```csharp
namespace YourProject.Dtos.Students
{
    public class UpdateStudentDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
```

---

# 5. **Dtos/Students/StudentResponseDto.cs**

```csharp
namespace YourProject.Dtos.Students
{
    public class StudentResponseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
```

---

# 6. **Controllers/StudentController.cs**

```csharp
using Microsoft.AspNetCore.Mvc;
using YourProject.Models;
using YourProject.Dtos.Students;

namespace YourProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        // GET: api/student
        [HttpGet]
        public ActionResult<IEnumerable<StudentResponseDto>> GetAll()
        {
            var result = SchoolRepository.Students
                .Select(s => new StudentResponseDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Email = s.Email,
                    Phone = s.Phone
                });

            return Ok(result);
        }

        // GET: api/student/3
        [HttpGet("{id:int}")]
        public ActionResult<StudentResponseDto> GetById(int id)
        {
            var student = SchoolRepository.GetById(id);
            if (student == null)
                return NotFound();

            var result = new StudentResponseDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Phone = student.Phone
            };

            return Ok(result);
        }

        // POST: api/student
        [HttpPost]
        public ActionResult<StudentResponseDto> Create(CreateStudentDto dto)
        {
            int newId = SchoolRepository.Students.Max(s => s.Id) + 1;

            var newStudent = new Student
            {
                Id = newId,
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone
            };

            SchoolRepository.Students.Add(newStudent);

            var response = new StudentResponseDto
            {
                Id = newStudent.Id,
                Name = newStudent.Name,
                Email = newStudent.Email,
                Phone = newStudent.Phone
            };

            return CreatedAtAction(nameof(GetById), new { id = newId }, response);
        }

        // PUT: api/student/3
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, UpdateStudentDto dto)
        {
            var student = SchoolRepository.GetById(id);
            if (student == null)
                return NotFound();

            student.Name = dto.Name;
            student.Email = dto.Email;
            student.Phone = dto.Phone;

            return NoContent();
        }

        // DELETE: api/student/3
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var student = SchoolRepository.GetById(id);
            if (student == null)
                return NotFound();

            SchoolRepository.Students.Remove(student);

            return NoContent();
        }
    }
}
```

---

# 7. **Program.cs** (for completeness)

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
```

---

# Ready to Start Coding

This setup gives you:

✔ Full CRUD
✔ DTOs
✔ Clean controller
✔ In-memory repository
✔ Swagger UI ready
✔ Ready to replace with EF Core later
