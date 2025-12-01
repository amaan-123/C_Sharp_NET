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

        // GET: api/courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseResponseDto>>> GetAll()
        {
            var courses = await _repo.GetAllAsync();
            var dtos = courses.Select(c => new CourseResponseDto
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

        // GET: api/courses/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CourseResponseDto>> GetById(int id)
        {
            var c = await _repo.GetByIdAsync(id);
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

        // GET: api/courses/department/{department}
        [HttpGet("department/{department}")]
        public async Task<ActionResult<IEnumerable<CourseResponseDto>>> GetByDepartment(string department)
        {
            var courses = await _repo.GetByDepartmentAsync(department);
            var dtos = courses.Select(c => new CourseResponseDto
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

        // POST: api/courses
        [HttpPost]
        public async Task<ActionResult<CourseResponseDto>> Create([FromBody] CreateCourseDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await _repo.CourseCodeExistsAsync(dto.CourseCode))
                return Conflict(new { message = "Course code already exists." });

            var course = new Course
            {
                CourseCode = dto.CourseCode,
                CourseName = dto.CourseName,
                Credits = dto.Credits,
                Department = dto.Department,
                Instructor = dto.Instructor
            };

            var created = await _repo.CreateAsync(course);

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

        // PUT: api/courses/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCourseDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();

            if (await _repo.CourseCodeExistsAsync(dto.CourseCode, exceptId: id))
                return Conflict(new { message = "Course code already exists." });

            existing.CourseCode = dto.CourseCode;
            existing.CourseName = dto.CourseName;
            existing.Credits = dto.Credits;
            existing.Department = dto.Department;
            existing.Instructor = dto.Instructor;

            var ok = await _repo.UpdateAsync(existing);
            if (!ok) return StatusCode(500);
            return NoContent();
        }

        // DELETE: api/courses/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _repo.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
