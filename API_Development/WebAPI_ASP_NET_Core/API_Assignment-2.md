## Assignment: Library Management System (Basic CRUD)

### Overview
Build a simple Library Management System API that manages books and authors. This assignment focuses on implementing basic CRUD operations with proper project structure.

### Requirements

#### 1. Models
Create the following models:

**Author Model:**
```csharp
public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string Biography { get; set; }
    public List<Book> Books { get; set; } = new List<Book>();
}
```

**Book Model:**
```csharp
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ISBN { get; set; }
    public int Pages { get; set; }
    public DateTime PublishedDate { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
}
```

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
   - Students (full CRUD)
   - Courses (full CRUD)
   - Additional endpoints:
     - `GET /api/students/department/{department}` - Get students by department
     - `GET /api/students/year/{year}` - Get students by year
     - `GET /api/courses/department/{department}` - Get courses by department
     - `GET /api/students/{id}/gpa` - Get student's GPA status (Pass/Fail based on GPA > 2.0)

3. **Business logic requirements:**
   - Students cannot have duplicate email addresses
   - Course codes must be unique
   - GPA calculations and status reporting
   - Proper error handling and status codes

### Deliverables
- Complete project with proper folder structure
- All model classes with appropriate validations
- Two controllers with full CRUD operations
- API documentation (can be simple markdown)
- Test results showing all endpoints working

---