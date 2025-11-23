using BooksAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            return Ok(BookRepository.books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            //before
            if (id <= 0)
            {
                return BadRequest("No negative Id's please");
            }
            var book = BookRepository.books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound($"Book with ID {id} not found");

            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> CreateBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var nextId = BookRepository.books.Count != 0 ? BookRepository.books.Max(b => b.Id) + 1 : 1;
            book.Id = nextId;
            BookRepository.books.Add(book);

            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            if (updatedBook == null)
                return BadRequest("Request body is null.");
            if (id <= 0)
            {
                return BadRequest("No negative Id's please");
            }

            if (updatedBook.Id != 0 && updatedBook.Id != id)
                ModelState.AddModelError("Id", "ID in body must match ID in URL."); //

            if (!TryValidateModel(updatedBook)) //
                return BadRequest(ModelState);

            var book = BookRepository.books.FirstOrDefault(b => b.Id == id);

            if (book == null)
                return NotFound($"Book with ID {id} not found");

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Genre = updatedBook.Genre;
            book.Pages = updatedBook.Pages;
            book.PublishedDate = updatedBook.PublishedDate;
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook(int id)
        {
            var book = BookRepository.books.FirstOrDefault(b => b.Id == id);
            if (id <= 0)
            {
                return BadRequest("No negative Id's please");
            }
            if (book == null)
                return NotFound($"Book with ID {id} not found");

            BookRepository.books.Remove(book);
            return NoContent();
        }

        [HttpGet("{genre:alpha}")]
        public ActionResult<IEnumerable<Book>> GetBooksByGenre(string genre)
        {
            if (string.IsNullOrWhiteSpace(genre))
                return BadRequest("Query parameter 'genre' is required.");

            var booksOfGenre = BookRepository.books
        .Where(b => b.Genre.Contains(genre))
        .ToList();

            // return 200 + empty list if none found (recommended for filter endpoints)
            return Ok(booksOfGenre);
        }
    }
}
