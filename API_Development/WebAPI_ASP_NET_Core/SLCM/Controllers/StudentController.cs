using Microsoft.AspNetCore.Mvc;
using SLCM.Model;

namespace SLCM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet("message")]
        public string ReturnString()
        {
            return "returning a string";
        }

        //commented when I moved it to SchoolRepository.cs
        //List<Student> students = new List<Student>()
        //{
        //    new Student { Id = 1, Name = "Tawheed", Email = "one@gmail.com", Phone = "9876543210" },
        //    new Student { Id = 2, Name = "Chad", Email = "multi@gmail.com", Phone = "8976543210" },
        //    new Student { Id = 3, Name = "Laddu", Email = "petu@gmail.com", Phone = "9856543210" }
        //};
        [HttpGet("GetAll")]
        public List<Student> GetAllStudents()
        {
            return SchoolRepository.students;
        }

        [HttpGet("{id:int}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = SchoolRepository.students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound(); // 404

            return Ok(student); // 200 + payload
        }

        [HttpGet("{name:alpha}")]
        public ActionResult<Student> GetStudentByName(string name)
        {
            var student = SchoolRepository.students.FirstOrDefault(s => s.Name.Contains(name));
            if (student == null)
                return NotFound();

            return Ok(student);
        }


    }
}
