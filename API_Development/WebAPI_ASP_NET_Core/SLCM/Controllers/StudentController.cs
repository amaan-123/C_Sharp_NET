using Microsoft.AspNetCore.Mvc;
using SLCM.Dtos.Students;
using SLCM.Models;

namespace SLCM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        //commented when I moved it to SchoolRepository.cs
        //List<Student> students = new List<Student>()
        //{
        //    new Student { Id = 1, Name = "Tawheed", Email = "one@gmail.com", Phone = "9876543210" },
        //    new Student { Id = 2, Name = "Chad", Email = "multi@gmail.com", Phone = "8976543210" },
        //    new Student { Id = 3, Name = "Laddu", Email = "petu@gmail.com", Phone = "9856543210" }
        //};

        //[HttpGet("WelcomeMessage")]
        //public string ReturnString()
        //{
        //    return "Welcome to Student Lifecycle Management System!";
        //}

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

        // without DTO, below is not a good practice to return all details of your actual data
        //[HttpGet("AllStudents")]
        //public List<Student> GetAllStudents()
        //{
        //    return SchoolRepository.Students;
        //}

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

        //[HttpGet("{id:int}")]
        //public ActionResult<Student> GetStudentById(int id)
        //{
        //    var student = SchoolRepository.Students.FirstOrDefault(s => s.Id == id);
        //    if (student == null)
        //        return NotFound(); // 404

        //    return Ok(student); // 200 + payload
        //}

        [HttpGet("{name:alpha}")]
        public ActionResult<Student> GetStudentByName(string name)
        {
            var student = SchoolRepository.Students.FirstOrDefault(s => s.Name.Contains(name));
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        // POST: api/student
        // Controllers: 
        // Accept DTOs from requests, convert them to Models, and send ResponseDTOs back.
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

        // trying to replace details(Name, Email, Phone) of a student keeping Id same
        // 3rd approach
        [HttpPut("{id:int}")]
        // PUT: api/student/3
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

        // my 3rd approach for above was first to use [FromBody]:
        //public IActionResult UpdateStudent(int id, [FromBody] UpdateStudentDto updatedStudent)
        //{
        //...//rest is same almost
        //}

        // My 2nd working approach (perfectly fine)
        // Just a polished addition in 3rd would be: to not even show id to the client for the request using Dto
        // even though it doesn't matter as anyways URL id is used.
        //[HttpPut("{id:int}")]
        //public IActionResult UpdateStudent(int id, [FromBody] Student updatedStudent)
        //{
        //    var student = SchoolRepository.students.FirstOrDefault(s => s.Id == id);
        //    if (student == null)
        //        return NotFound();
        //    else
        //    {
        //        // Update properties
        //        student.Name = updatedStudent.Name;
        //        student.Email = updatedStudent.Email;
        //        student.Phone = updatedStudent.Phone;
        //        return NoContent();
        //    }
        //}

        // Below is my first working approach, but it is NOT a proper approach:
        // PUT = update, so return NoContent() OR Ok().
        // Never return Created() for PUT.
        // Prefer `IActionResult` return type.
        // Accept a model object from body, not separate parameters.
        // Avoid `id - 1` indexing; always find by ID.

        //[HttpPut("{id:int}")]
        //public ActionResult<Student> UpdateStudent(int id, string name, string email, string phone)
        //{
        //    var student = SchoolRepository.students.FirstOrDefault(s => s.Id == id);
        //    if (SchoolRepository.students.Contains(student))
        //    {
        //        var student1 = new Student { Id = id, Name = name, Email = email, Phone = phone };
        //        SchoolRepository.students[id - 1] = student1;
        //        return Created();
        //    }
        //    else return NotFound();
        //}


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

        //2nd approach, her better to not be specific with ActionResult<T>, as you usually don't return data for delete
        //public ActionResult<Student> DeleteStudent(int id)
        //{
        //    var student = SchoolRepository.Students.FirstOrDefault(s => s.Id == id);
        //    if (student == null)
        //        return NotFound();
        //    else if (SchoolRepository.Students.Remove(student))
        //    {
        //        return NoContent();
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        // 1st approach
        //public bool DeleteStudent(int id)
        //{
        //    var student = SchoolRepository.students.FirstOrDefault(s => s.Id == id);
        //    if (student == null)
        //        return false;

        //    return SchoolRepository.students.Remove(student);
        //}


    }
}
