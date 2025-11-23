using System.ComponentModel.DataAnnotations;

namespace LMS_API.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [Required, StringLength(100)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [StringLength(2000)]
        public string Biography { get; set; }

        public List<Book> Books { get; set; } = new();
    }
}
