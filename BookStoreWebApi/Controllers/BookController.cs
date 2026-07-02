using BookStoreWebApi.Data;
using BookStoreWebApi.DTOs;
using BookStoreWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public BookController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Added Book Details
        [HttpPost]
        public string AddBookDetail(BookDTO dto)
        {
            if (dto != null)
            {
                var book = new Book() { Title = dto.Title, Author = dto.Author, Description = dto.Description, Price = dto.Price };
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
            }
            return "Inserted";
        }

        //Fetch all Books Details
        [HttpGet]
        public ActionResult<List<Book>> GetBooks()
        {
            var books = _dbContext.Books.ToList();
            if (books == null)
            {
                return NotFound("Book does not exist.");
            }
            return Ok(books);
        }

        //Fetch a book through Id
        [HttpGet("{id:int}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _dbContext.Books.Find(id);
            if (book == null)
            {
                return NotFound("Book Not Found");
            }
            return Ok(book);
        }

        //Update a book through Id
        [HttpPut("{id:int}")]
        public ActionResult<Book> UpdateBook(BookDTO book, int id)
        {
            var _book = _dbContext.Books.Find(id);
            if (_book == null)
            {
                return NotFound("Book Not Found");
            }

            _book.Title = book.Title;
            _book.Author = book.Author;
            _book.Description = book.Description;
            _book.Price = book.Price;

            _dbContext.SaveChanges();

            return Ok(_book);
        }

        //Delete a book through Id
        [HttpDelete("{id:int}")]
        public ActionResult<Book> DeleteBook(int id)
        {
            var _book = _dbContext.Books.Find(id);
            if (_book == null)
            {
                return NotFound("Book Not Found");
            }

            _dbContext.Books.Remove(_book);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
