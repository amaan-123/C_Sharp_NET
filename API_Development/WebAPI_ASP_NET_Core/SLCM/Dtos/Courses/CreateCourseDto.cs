using System.ComponentModel.DataAnnotations;

namespace SLCM.Dtos.Courses
{
    public class CreateCourseDto
    {
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
