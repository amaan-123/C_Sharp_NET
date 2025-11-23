namespace BooksAPI.Models
{
    public static class BookRepository
    {
        public static List<Book> books = new List<Book>()
        {
            new Book { Id = 1, Title = "ad-Daa wad-Dawaa (al-Jawab al-Kaafi)", Author = "Ibn Qayyim al-Jawziyya", Pages = 439, Genre = "Belief", PublishedDate = new DateTime(2020, 1, 01) },
            new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Pages = 281, Genre = "Fiction", PublishedDate = new DateTime(1960, 7, 11) }
        };
    }
}