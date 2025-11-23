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
