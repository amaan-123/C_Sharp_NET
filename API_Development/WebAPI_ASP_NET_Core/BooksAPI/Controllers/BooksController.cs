using BooksAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private static List<Book> books = new List<Book>
    {
        new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Pages = 180, Genre = "Fiction", PublishedDate = new DateTime(1925, 4, 10) },
        new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Pages = 281, Genre = "Fiction", PublishedDate = new DateTime(1960, 7, 11) }
    };

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound($"Book with ID {id} not found");

            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            book.Id = books.Max(b => b.Id) + 1;
            books.Add(book);

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }
    }
}
