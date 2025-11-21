using System.ComponentModel.DataAnnotations;

namespace BooksAPI.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Author { get; set; } = string.Empty;

        [Range(1, 5000)]
        public int Pages { get; set; }

        [Required]
        public string Genre { get; set; } = string.Empty;

        public DateTime PublishedDate { get; set; }
    }
}
