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

        [Range(1, 4)]
        public int Year { get; set; } = 1;

        [Range(0.0, 4.0)]
        public double GPA { get; set; } = 0.0;

        public bool IsActive { get; set; } = true;
    }
}
