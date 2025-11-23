using System.ComponentModel.DataAnnotations;

public class AuthorCreateDto
{
    [Required, StringLength(100)] public string FirstName { get; set; }
    [Required, StringLength(100)] public string LastName { get; set; }
    [Required] public DateTime DateOfBirth { get; set; }
    [Required, EmailAddress] public string Email { get; set; }
    [StringLength(2000)] public string Biography { get; set; }
}
