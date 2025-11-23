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

//////commented when I moved it to SchoolRepository.cs
//////List<Student> students = new List<Student>()
//////{
//////    new Student { Id = 1, Name = "Tawheed", Email = "one@gmail.com", Phone = "9876543210" },
//////    new Student { Id = 2, Name = "Chad", Email = "multi@gmail.com", Phone = "8976543210" },
//////    new Student { Id = 3, Name = "Laddu", Email = "petu@gmail.com", Phone = "9856543210" }
//////};

//////[HttpGet("WelcomeMessage")]
//////public string ReturnString()
//////{
//////    return "Welcome to Student Lifecycle Management System!";
//////}

//// Methods changed For EF Core Database video
//// GET: api/student
//private readonly SLCMContext _context;
//public StudentController(SLCMContext context)
//{
//    _context = context;
//}

//[HttpGet]
//public async Task<ActionResult<List<StudentResponseDto>>> GetStudents()
//{
//    var students = await _context.Students
//        .Select(s => new StudentResponseDto
//        {
//            Id = s.Id,
//            Name = s.Name,
//            Email = s.Email,
//            Phone = s.Phone
//        })
//        .ToListAsync();

//    return Ok(students);
//}
////// GET: api/student
////[HttpGet]
////public ActionResult<IEnumerable<StudentResponseDto>> GetAll()
////{
////    var result = SchoolRepository.Students
////        .Select(s => new StudentResponseDto
////        {
////            Id = s.Id,
////            Name = s.Name,
////            Email = s.Email,
////            Phone = s.Phone
////        });

////    return Ok(result);
////}

////// without DTO, below is not a good practice to return all details of your actual data

//// GET: api/student/3
//[HttpGet("{id:int}")]
//public async Task<ActionResult<StudentResponseDto>> GetById(int id)
//{
//    var student = await _context.Students.FindAsync(id);
//    if (student == null)
//        return NotFound();

//    var result = new StudentResponseDto
//    {
//        Id = student.Id,
//        Name = student.Name,
//        Email = student.Email,
//        Phone = student.Phone
//    };

//    return Ok(result);
//}

//// POST: api/student
//// Controllers: 
//// Accept DTOs from requests, convert them to Models, and send ResponseDTOs back.
//[HttpPost]
//public async Task<ActionResult<StudentResponseDto>> Create(CreateStudentDto dto)
//{
//    // Let the database generate the Id (identity column). Do not set Id explicitly.
//    var newStudent = new Student
//    {
//        Name = dto.Name,
//        Email = dto.Email,
//        Phone = dto.Phone
//    };

//    _context.Students.Add(newStudent);
//    await _context.SaveChangesAsync();

//    //TODO: access from database
//    var response = new StudentResponseDto
//    {
//        Id = newStudent.Id,
//        Name = newStudent.Name,
//        Email = newStudent.Email,
//        Phone = newStudent.Phone
//    };

//    return CreatedAtAction(nameof(GetById), new { id = newStudent.Id }, response);
//}

//[HttpPut("{id:int}")]
//// PUT: api/student/3
//public async Task<IActionResult> Update(int id, UpdateStudentDto dto)
//{
//    var student = await _context.Students.FindAsync(id);
//    if (student == null)
//        return NotFound();

//    student.Name = dto.Name;
//    student.Email = dto.Email;
//    student.Phone = dto.Phone;

//    await _context.SaveChangesAsync();

//    return NoContent();
//}

////// trying to replace details(Name, Email, Phone) of a student keeping Id same
////// 3rd approach
////[HttpPut("{id:int}")]
////// PUT: api/student/3
////public IActionResult Update(int id, UpdateStudentDto dto)
////{
////    var student = SchoolRepository.GetById(id);
////    if (student == null)
////        return NotFound();

////    student.Name = dto.Name;
////    student.Email = dto.Email;
////    student.Phone = dto.Phone;

////    return NoContent();
////}

////// my 3rd approach for above was first to use [FromBody]:
//////public IActionResult UpdateStudent(int id, [FromBody] UpdateStudentDto updatedStudent)
//////{
//////...//rest is same almost
//////}

////// My 2nd working approach (perfectly fine)
////// Just a polished addition in 3rd would be: to not even show id to the client for the request using Dto
////// even though it doesn't matter as anyways URL id is used.
//////[HttpPut("{id:int}")]
//////public IActionResult UpdateStudent(int id, [FromBody] Student updatedStudent)
//////{
//////    var student = SchoolRepository.students.FirstOrDefault(s => s.Id == id);
//////    if (student == null)
//////        return NotFound();
//////    else
//////    {
//////        // Update properties
//////        student.Name = updatedStudent.Name;
//////        student.Email = updatedStudent.Email;
//////        student.Phone = updatedStudent.Phone;
//////        return NoContent();
//////    }
//////}

////// Below is my first working approach, but it is NOT a proper approach:
////// PUT = update, so return NoContent() OR Ok().
////// Never return Created() for PUT.
////// Prefer `IActionResult` return type.
////// Accept a model object from body, not separate parameters.
////// Avoid `id - 1` indexing; always find by ID.

//////[HttpPut("{id:int}")]
//////public ActionResult<Student> UpdateStudent(int id, string name, string email, string phone)
//////{
//////    var student = SchoolRepository.students.FirstOrDefault(s => s.Id == id);
//////    if (SchoolRepository.students.Contains(student))
//////    {
//////        var student1 = new Student { Id = id, Name = name, Email = email, Phone = phone };
//////        SchoolRepository.students[id - 1] = student1;
//////        return Created();
//////    }
//////    else return NotFound();
//////}

//// DELETE: api/student/3
//[HttpDelete("{id:int}")]
//public async Task<IActionResult> Delete(int id)
//{
//    var student = await _context.Students.FindAsync(id);
//    if (student == null)
//        return NotFound();

//    _context.Students.Remove(student);
//    await _context.SaveChangesAsync();

//    return NoContent();
//}

////// DELETE: api/student/3
////[HttpDelete("{id:int}")]
////public IActionResult Delete(int id)
////{
////    var student = SchoolRepository.GetById(id);
////    if (student == null)
////        return NotFound();

////    SchoolRepository.Students.Remove(student);

////    return NoContent();
////}

//////2nd approach, her better to not be specific with ActionResult<T>, as you usually don't return data for delete
//////public ActionResult<Student> DeleteStudent(int id)
//////{
//////    var student = SchoolRepository.Students.FirstOrDefault(s => s.Id == id);
//////    if (student == null)
//////        return NotFound();
//////    else if (SchoolRepository.Students.Remove(student))
//////    {
//////        return NoContent();
//////    }
//////    else
//////    {
//////        return NotFound();
//////    }
//////}

////// 1st approach
//////public bool DeleteStudent(int id)
//////{
//////    var student = SchoolRepository.students.FirstOrDefault(s => s.Id == id);
//////    if (student == null)
//////        return false;

//////    return SchoolRepository.students.Remove(student);
//////}