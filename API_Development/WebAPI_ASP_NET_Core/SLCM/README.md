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

*"Tutorial: Create a controller-based web API with ASP.NET Core"*
> <https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-10.0&tabs=visual-studio>

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

# Q) Can we change our existing SLCM project to do:?

## Assignment 2: Student Management API (Intermediate Level)

### Task Description

Create a comprehensive Student Management API from scratch with proper project structure.

### Requirements

1. **Create the following models:**

   ```csharp
   public class Student
   {
       public int Id { get; set; }
       [Required, StringLength(50)]
       public string FirstName { get; set; }
       [Required, StringLength(50)]
       public string LastName { get; set; }
       [Required, EmailAddress]
       public string Email { get; set; }
       [Required, Phone]
       public string PhoneNumber { get; set; }
       [Required]
       public string Department { get; set; }
       [Range(1, 4)]
       public int Year { get; set; }
       [Range(0.0, 4.0)]
       public double GPA { get; set; }
       public DateTime EnrollmentDate { get; set; }
       public bool IsActive { get; set; }
   }

   public class Course
   {
       public int Id { get; set; }
       [Required, StringLength(10)]
       public string CourseCode { get; set; }
       [Required, StringLength(100)]
       public string CourseName { get; set; }
       [Range(1, 6)]
       public int Credits { get; set; }
       public string Department { get; set; }
       public string Instructor { get; set; }
   }
   ```

2. **Implement controllers for:**
   * Students (full CRUD)
   * Courses (full CRUD)
   * Additional endpoints:
     * `GET /api/students/department/{department}` - Get students by department
     * `GET /api/students/year/{year}` - Get students by year
     * `GET /api/courses/department/{department}` - Get courses by department
     * `GET /api/students/{id}/gpa` - Get student's GPA status (Pass/Fail based on GPA > 2.0)

3. **Business logic requirements:**
   * Students cannot have duplicate email addresses
   * Course codes must be unique
   * GPA calculations and status reporting
   * Proper error handling and status codes

### Deliverables

* Complete project with proper folder structure

* All model classes with appropriate validations
* Two controllers with full CRUD operations
* API documentation (can be simple markdown)
* Test results showing all endpoints working

Yes — we can. Below I’ve converted your SLCM project into **Assignment 2: Student Management API (Intermediate)** by giving you a ready-to-use project layout and all the starter code you need (models, DTOs, in-memory repositories, controllers, Program.cs, and brief API docs + test examples). Copy these files into your project, build, run, and test in Swagger.

---

# Project folder structure (exact)

```
SLCM/
├── Controllers/
│   ├── StudentsController.cs
│   └── CoursesController.cs
│
├── Data/
│   └── SchoolData.cs
│
├── Models/
│   ├── Student.cs
│   └── Course.cs
│
├── Dtos/
│   ├── Students/
│   │   ├── CreateStudentDto.cs
│   │   ├── UpdateStudentDto.cs
│   │   └── StudentResponseDto.cs
│   └── Courses/
│       ├── CreateCourseDto.cs
│       ├── UpdateCourseDto.cs
│       └── CourseResponseDto.cs
│
├── Repositories/
│   ├── IStudentRepository.cs
│   ├── StudentRepository.cs
│   ├── ICourseRepository.cs
│   └── CourseRepository.cs
│
├── Program.cs
└── SLCM.csproj
```

---

## 1) Models

**Models/Student.cs**

```csharp
using System;
using System.ComponentModel.DataAnnotations;

namespace SLCM.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Department { get; set; } = string.Empty;

        [Range(1, 4)]
        public int Year { get; set; } = 1;

        [Range(0.0, 4.0)]
        public double GPA { get; set; } = 0.0;

        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;
    }
}
```

**Models/Course.cs**

```csharp
using System.ComponentModel.DataAnnotations;

namespace SLCM.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required, StringLength(10)]
        public string CourseCode { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string CourseName { get; set; } = string.Empty;

        [Range(1, 6)]
        public int Credits { get; set; } = 3;

        public string? Department { get; set; }
        public string? Instructor { get; set; }
    }
}
```

---

## 2) DTOs

**Dtos/Students/CreateStudentDto.cs**

```csharp
using System.ComponentModel.DataAnnotations;

namespace SLCM.Dtos.Students
{
    public class CreateStudentDto
    {
        [Required, StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Department { get; set; } = string.Empty;

        [Range(1,4)]
        public int Year { get; set; } = 1;

        [Range(0.0, 4.0)]
        public double GPA { get; set; } = 0.0;

        public bool IsActive { get; set; } = true;
    }
}
```

**Dtos/Students/UpdateStudentDto.cs**

```csharp
using System.ComponentModel.DataAnnotations;

namespace SLCM.Dtos.Students
{
    public class UpdateStudentDto
    {
        [Required, StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Department { get; set; } = string.Empty;

        [Range(1,4)]
        public int Year { get; set; } = 1;

        [Range(0.0,4.0)]
        public double GPA { get; set; } = 0.0;

        public bool IsActive { get; set; } = true;
    }
}
```

**Dtos/Students/StudentResponseDto.cs**

```csharp
namespace SLCM.Dtos.Students
{
    public class StudentResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public int Year { get; set; }
        public double GPA { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public bool IsActive { get; set; }
    }
}
```

**Dtos/Courses/CreateCourseDto.cs**

```csharp
using System.ComponentModel.DataAnnotations;

namespace SLCM.Dtos.Courses
{
    public class CreateCourseDto
    {
        [Required, StringLength(10)]
        public string CourseCode { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string CourseName { get; set; } = string.Empty;

        [Range(1,6)]
        public int Credits { get; set; } = 3;

        public string? Department { get; set; }
        public string? Instructor { get; set; }
    }
}
```

**Dtos/Courses/UpdateCourseDto.cs**

```csharp
using System.ComponentModel.DataAnnotations;

namespace SLCM.Dtos.Courses
{
    public class UpdateCourseDto
    {
        [Required, StringLength(10)]
        public string CourseCode { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string CourseName { get; set; } = string.Empty;

        [Range(1,6)]
        public int Credits { get; set; } = 3;

        public string? Department { get; set; }
        public string? Instructor { get; set; }
    }
}
```

**Dtos/Courses/CourseResponseDto.cs**

```csharp
namespace SLCM.Dtos.Courses
{
    public class CourseResponseDto
    {
        public int Id { get; set; }
        public string CourseCode { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public int Credits { get; set; }
        public string? Department { get; set; }
        public string? Instructor { get; set; }
    }
}
```

---

## 3) Simple in-memory data store

**Data/SchoolData.cs**

```csharp
using System;
using System.Collections.Generic;
using SLCM.Models;

namespace SLCM.Data
{
    public static class SchoolData
    {
        public static List<Student> Students { get; } = new List<Student>
        {
            new Student { Id = 1, FirstName = "Tawheed", LastName = "K", Email = "one@gmail.com", PhoneNumber = "9876543210", Department = "CS", Year = 2, GPA = 3.2, EnrollmentDate = DateTime.UtcNow.AddYears(-1), IsActive = true },
            new Student { Id = 2, FirstName = "Chad", LastName = "L", Email = "multi@gmail.com", PhoneNumber = "8976543210", Department = "EE", Year = 3, GPA = 2.5, EnrollmentDate = DateTime.UtcNow.AddYears(-2), IsActive = true },
            new Student { Id = 3, FirstName = "Laddu", LastName = "M", Email = "petu@gmail.com", PhoneNumber = "9856543210", Department = "CS", Year = 1, GPA = 1.8, EnrollmentDate = DateTime.UtcNow.AddYears(-1), IsActive = true }
        };

        public static List<Course> Courses { get; } = new List<Course>
        {
            new Course { Id = 1, CourseCode = "CS101", CourseName = "Intro to CS", Credits = 3, Department = "CS", Instructor = "Prof A" },
            new Course { Id = 2, CourseCode = "EE201", CourseName = "Circuits", Credits = 4, Department = "EE", Instructor = "Prof B" }
        };
    }
}
```

---

## 4) Repositories (simple, thread-safe via lock)

**Repositories/IStudentRepository.cs**

```csharp
using System.Collections.Generic;
using SLCM.Models;

namespace SLCM.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student? GetById(int id);
        Student Create(Student student);
        bool Update(Student student);
        bool Delete(int id);
        IEnumerable<Student> GetByDepartment(string department);
        IEnumerable<Student> GetByYear(int year);
        bool EmailExists(string email, int? exceptId = null);
    }
}
```

**Repositories/StudentRepository.cs**

```csharp
using System.Collections.Generic;
using System.Linq;
using SLCM.Data;
using SLCM.Models;

namespace SLCM.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private static readonly object _lock = new();
        public IEnumerable<Student> GetAll() => SchoolData.Students;

        public Student? GetById(int id) => SchoolData.Students.FirstOrDefault(s => s.Id == id);

        public Student Create(Student student)
        {
            lock (_lock)
            {
                var newId = SchoolData.Students.Any() ? SchoolData.Students.Max(s => s.Id) + 1 : 1;
                student.Id = newId;
                SchoolData.Students.Add(student);
                return student;
            }
        }

        public bool Update(Student student)
        {
            lock (_lock)
            {
                var existing = GetById(student.Id);
                if (existing == null) return false;
                existing.FirstName = student.FirstName;
                existing.LastName = student.LastName;
                existing.Email = student.Email;
                existing.PhoneNumber = student.PhoneNumber;
                existing.Department = student.Department;
                existing.Year = student.Year;
                existing.GPA = student.GPA;
                existing.IsActive = student.IsActive;
                return true;
            }
        }

        public bool Delete(int id)
        {
            lock (_lock)
            {
                var existing = GetById(id);
                if (existing == null) return false;
                return SchoolData.Students.Remove(existing);
            }
        }

        public IEnumerable<Student> GetByDepartment(string department)
            => SchoolData.Students.Where(s => string.Equals(s.Department, department, System.StringComparison.OrdinalIgnoreCase));

        public IEnumerable<Student> GetByYear(int year)
            => SchoolData.Students.Where(s => s.Year == year);

        public bool EmailExists(string email, int? exceptId = null)
            => SchoolData.Students.Any(s => s.Email.Equals(email, System.StringComparison.OrdinalIgnoreCase) && (!exceptId.HasValue || s.Id != exceptId.Value));
    }
}
```

**Repositories/ICourseRepository.cs**

```csharp
using System.Collections.Generic;
using SLCM.Models;

namespace SLCM.Repositories
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        Course? GetById(int id);
        Course Create(Course course);
        bool Update(Course course);
        bool Delete(int id);
        bool CourseCodeExists(string courseCode, int? exceptId = null);
        IEnumerable<Course> GetByDepartment(string department);
    }
}
```

**Repositories/CourseRepository.cs**

```csharp
using System.Collections.Generic;
using System.Linq;
using SLCM.Data;
using SLCM.Models;

namespace SLCM.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private static readonly object _lock = new();

        public IEnumerable<Course> GetAll() => SchoolData.Courses;

        public Course? GetById(int id) => SchoolData.Courses.FirstOrDefault(c => c.Id == id);

        public Course Create(Course course)
        {
            lock (_lock)
            {
                var newId = SchoolData.Courses.Any() ? SchoolData.Courses.Max(c => c.Id) + 1 : 1;
                course.Id = newId;
                SchoolData.Courses.Add(course);
                return course;
            }
        }

        public bool Update(Course course)
        {
            lock (_lock)
            {
                var existing = GetById(course.Id);
                if (existing == null) return false;
                existing.CourseCode = course.CourseCode;
                existing.CourseName = course.CourseName;
                existing.Credits = course.Credits;
                existing.Department = course.Department;
                existing.Instructor = course.Instructor;
                return true;
            }
        }

        public bool Delete(int id)
        {
            lock (_lock)
            {
                var existing = GetById(id);
                if (existing == null) return false;
                return SchoolData.Courses.Remove(existing);
            }
        }

        public bool CourseCodeExists(string courseCode, int? exceptId = null)
            => SchoolData.Courses.Any(c => c.CourseCode.Equals(courseCode, System.StringComparison.OrdinalIgnoreCase) && (!exceptId.HasValue || c.Id != exceptId.Value));

        public IEnumerable<Course> GetByDepartment(string department)
            => SchoolData.Courses.Where(c => string.Equals(c.Department, department, System.StringComparison.OrdinalIgnoreCase));
    }
}
```

---

## 5) Controllers (with validations & business rules)

**Controllers/StudentsController.cs**

```csharp
using Microsoft.AspNetCore.Mvc;
using SLCM.Dtos.Students;
using SLCM.Models;
using SLCM.Repositories;

namespace SLCM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _repo;

        public StudentsController(IStudentRepository repo) => _repo = repo;

        // GET api/students
        [HttpGet]
        public ActionResult<IEnumerable<StudentResponseDto>> GetAll()
        {
            var dtos = _repo.GetAll().Select(s => MapToResponse(s));
            return Ok(dtos);
        }

        // GET api/students/{id}
        [HttpGet("{id:int}")]
        public ActionResult<StudentResponseDto> GetById(int id)
        {
            var s = _repo.GetById(id);
            if (s == null) return NotFound();
            return Ok(MapToResponse(s));
        }

        // GET api/students/department/{department}
        [HttpGet("department/{department}")]
        public ActionResult<IEnumerable<StudentResponseDto>> GetByDepartment(string department)
        {
            var dtos = _repo.GetByDepartment(department).Select(s => MapToResponse(s));
            return Ok(dtos);
        }

        // GET api/students/year/{year}
        [HttpGet("year/{year:int}")]
        public ActionResult<IEnumerable<StudentResponseDto>> GetByYear(int year)
        {
            var dtos = _repo.GetByYear(year).Select(s => MapToResponse(s));
            return Ok(dtos);
        }

        // GET api/students/{id}/gpa
        [HttpGet("{id:int}/gpa")]
        public ActionResult GetGpaStatus(int id)
        {
            var s = _repo.GetById(id);
            if (s == null) return NotFound();

            var status = s.GPA > 2.0 ? "Pass" : "Fail";
            return Ok(new { Id = s.Id, Gpa = s.GPA, Status = status });
        }

        // POST api/students
        [HttpPost]
        public ActionResult<StudentResponseDto> Create([FromBody] CreateStudentDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_repo.EmailExists(dto.Email)) return Conflict(new { message = "Email already exists." });

            var student = new Student
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Department = dto.Department,
                Year = dto.Year,
                GPA = dto.GPA,
                EnrollmentDate = DateTime.UtcNow,
                IsActive = dto.IsActive
            };

            var created = _repo.Create(student);
            var response = MapToResponse(created);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, response);
        }

        // PUT api/students/{id}
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UpdateStudentDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existing = _repo.GetById(id);
            if (existing == null) return NotFound();

            if (_repo.EmailExists(dto.Email, exceptId: id)) return Conflict(new { message = "Email already exists." });

            existing.FirstName = dto.FirstName;
            existing.LastName = dto.LastName;
            existing.Email = dto.Email;
            existing.PhoneNumber = dto.PhoneNumber;
            existing.Department = dto.Department;
            existing.Year = dto.Year;
            existing.GPA = dto.GPA;
            existing.IsActive = dto.IsActive;

            var ok = _repo.Update(existing);
            if (!ok) return StatusCode(500);
            return NoContent();
        }

        // DELETE api/students/{id}
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var success = _repo.Delete(id);
            if (!success) return NotFound();
            return NoContent();
        }

        // mapping
        private static StudentResponseDto MapToResponse(Student s) => new StudentResponseDto
        {
            Id = s.Id,
            FirstName = s.FirstName,
            LastName = s.LastName,
            Email = s.Email,
            PhoneNumber = s.PhoneNumber,
            Department = s.Department,
            Year = s.Year,
            GPA = s.GPA,
            EnrollmentDate = s.EnrollmentDate,
            IsActive = s.IsActive
        };
    }
}
```

**Controllers/CoursesController.cs**

```csharp
using Microsoft.AspNetCore.Mvc;
using SLCM.Dtos.Courses;
using SLCM.Models;
using SLCM.Repositories;

namespace SLCM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _repo;

        public CoursesController(ICourseRepository repo) => _repo = repo;

        // GET api/courses
        [HttpGet]
        public ActionResult<IEnumerable<CourseResponseDto>> GetAll()
        {
            var dtos = _repo.GetAll().Select(c => new CourseResponseDto
            {
                Id = c.Id,
                CourseCode = c.CourseCode,
                CourseName = c.CourseName,
                Credits = c.Credits,
                Department = c.Department,
                Instructor = c.Instructor
            });

            return Ok(dtos);
        }

        // GET api/courses/{id}
        [HttpGet("{id:int}")]
        public ActionResult<CourseResponseDto> GetById(int id)
        {
            var c = _repo.GetById(id);
            if (c == null) return NotFound();
            return Ok(new CourseResponseDto
            {
                Id = c.Id,
                CourseCode = c.CourseCode,
                CourseName = c.CourseName,
                Credits = c.Credits,
                Department = c.Department,
                Instructor = c.Instructor
            });
        }

        // GET api/courses/department/{department}
        [HttpGet("department/{department}")]
        public ActionResult<IEnumerable<CourseResponseDto>> GetByDepartment(string department)
        {
            var dtos = _repo.GetByDepartment(department).Select(c => new CourseResponseDto
            {
                Id = c.Id,
                CourseCode = c.CourseCode,
                CourseName = c.CourseName,
                Credits = c.Credits,
                Department = c.Department,
                Instructor = c.Instructor
            });

            return Ok(dtos);
        }

        // POST api/courses
        [HttpPost]
        public ActionResult<CourseResponseDto> Create([FromBody] CreateCourseDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_repo.CourseCodeExists(dto.CourseCode)) return Conflict(new { message = "Course code already exists." });

            var course = new Course
            {
                CourseCode = dto.CourseCode,
                CourseName = dto.CourseName,
                Credits = dto.Credits,
                Department = dto.Department,
                Instructor = dto.Instructor
            };

            var created = _repo.Create(course);

            var response = new CourseResponseDto
            {
                Id = created.Id,
                CourseCode = created.CourseCode,
                CourseName = created.CourseName,
                Credits = created.Credits,
                Department = created.Department,
                Instructor = created.Instructor
            };

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, response);
        }

        // PUT api/courses/{id}
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UpdateCourseDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existing = _repo.GetById(id);
            if (existing == null) return NotFound();

            if (_repo.CourseCodeExists(dto.CourseCode, exceptId: id)) return Conflict(new { message = "Course code already exists." });

            existing.CourseCode = dto.CourseCode;
            existing.CourseName = dto.CourseName;
            existing.Credits = dto.Credits;
            existing.Department = dto.Department;
            existing.Instructor = dto.Instructor;

            var ok = _repo.Update(existing);
            if (!ok) return StatusCode(500);
            return NoContent();
        }

        // DELETE api/courses/{id}
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var success = _repo.Delete(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
```

---

## 6) Program.cs — register repositories and enable swagger

**Program.cs**

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register repositories (in-memory)
builder.Services.AddSingleton<SLCM.Repositories.IStudentRepository, SLCM.Repositories.StudentRepository>();
builder.Services.AddSingleton<SLCM.Repositories.ICourseRepository, SLCM.Repositories.CourseRepository>();

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

## 7) API documentation (brief) — put in a docs/README.md or markdown file

**API Endpoints (core)**

Students

* `GET /api/students` — get all students
* `GET /api/students/{id}` — get student by id
* `POST /api/students` — create student (body = CreateStudentDto)
* `PUT /api/students/{id}` — update student (body = UpdateStudentDto)
* `DELETE /api/students/{id}` — delete student
* `GET /api/students/department/{department}` — get by department
* `GET /api/students/year/{year}` — get by year
* `GET /api/students/{id}/gpa` — returns `{ Id, Gpa, Status }` where Status = Pass if GPA > 2.0

Courses

* `GET /api/courses` — get all courses
* `GET /api/courses/{id}` — get course by id
* `POST /api/courses` — create course (body = CreateCourseDto)
* `PUT /api/courses/{id}` — update course (body = UpdateCourseDto)
* `DELETE /api/courses/{id}` — delete course
* `GET /api/courses/department/{department}` — get courses by department

**Business rules**

* Student emails must be unique → `409 Conflict` if duplicate
* Course codes must be unique → `409 Conflict` if duplicate
* GPA status endpoint: pass if GPA > 2.0 else fail
* Validation attributes applied; invalid model → `400 Bad Request`

---

## 8) Tests you can run quickly (manual with Swagger / curl)

1. **Create student (success)**
   POST `/api/students` body:

```json
{
  "firstName": "Test",
  "lastName": "User",
  "email": "testuser@example.com",
  "phoneNumber": "9999999999",
  "department": "CS",
  "year": 2,
  "gpa": 3.1,
  "isActive": true
}
```

Expect `201 Created` and Location header.

2. **Create duplicate email (failure)**
   Repeat above with same email → expect `409 Conflict`.

3. **Get by department**
   GET `/api/students/department/CS` → 200 with list.

4. **Get GPA status**
   GET `/api/students/1/gpa` → 200 `{ Id, Gpa, Status }`.

5. **Course creation and duplicate code check**
   POST `/api/courses` with `courseCode: "CS101"` already existing → 409 Conflict.

6. **Update student**
   PUT `/api/students/{id}` with UpdateStudentDto → 204 No Content; then GET and verify.

---

## 9) Notes & next steps (EF Core migration plan)

* When ready to use EF Core:

  * Add `AppDbContext` in `Data/` with DbSet<Student>, DbSet<Course>
  * Replace repositories' in-memory implementation with EF Core implementations using `DbContext`
  * Update registration in Program.cs to use `AddDbContext`
  * Add migrations and update database
* Use AutoMapper later to simplify DTO ↔ Model mapping.

---
