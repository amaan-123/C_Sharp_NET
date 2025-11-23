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
