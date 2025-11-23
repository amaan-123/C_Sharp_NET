using System.ComponentModel.DataAnnotations;

public class BookUpdateDto
{
    [Required, StringLength(200)] public string Title { get; set; }
    [Required, StringLength(13, MinimumLength = 13)] public string ISBN { get; set; }
    [Range(1, int.MaxValue)] public int Pages { get; set; }
    [Required] public DateTime PublishedDate { get; set; }
    [Range(0.01, double.MaxValue)] public decimal Price { get; set; }
    public bool IsAvailable { get; set; } = true;
    [Required] public int AuthorId { get; set; }
}
