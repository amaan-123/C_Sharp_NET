public class BookReadDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ISBN { get; set; }
    public int Pages { get; set; }
    public DateTime PublishedDate { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    public int AuthorId { get; set; }
    public string AuthorName { get; set; }
}
