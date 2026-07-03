using BookStoreWebApi.Data;
using BookStoreWebApi.DTOs;
using BookStoreWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public string AddBookDetail(BookRequestDTO dto)
        {
            if (dto != null)
            {
                var book = new Book() { Title = dto.Title, Author = dto.Author, Description = dto.Description, Price = dto.Price };
                _dbContext.Books.Add(book);//Added means added in memory only
                _dbContext.SaveChanges();//means data is persist now
            }
            return "Inserted";
        }

        //Fetch all Books Details
        [HttpGet]
        public ActionResult<List<Book>> GetBooks()
        {
            // var books = _dbContext.Books.ToList();//It is bad practice

            /**var books = _dbContext.Books.ToList();
            var filterBooks = books.Where(x => x.Price > 500);//It is also bad practice
            */
            Console.WriteLine("Before Query : ");
            //var books = _dbContext.Books.Where(book => book.Price > 500);//It is deffered Execution and it is not exection in sql server
            var books = _dbContext.Books.Where(book => book.Price > 500).ToList();//It is deffered Execution and it is exection in sql server
            Console.WriteLine("After Query : ");
            if (books == null)
            {
                return NotFound("Book does not exist.");
            }
            Console.WriteLine("Sabke bad ki Query : ");
            return Ok(books);
        }

        //Fetch a book through Id
        [HttpGet("{id:int}")]
        public ActionResult<Book> GetBook(int id)
        {

            //var book = _dbContext.Books.Find(id);//means Unchange tracking is on
            var book = _dbContext.Books.AsNoTracking().FirstOrDefault(book => book.Id == id);//means Detached mode and tracking is disable now and it's ReadOnly
            if (book == null)
            {
                return NotFound("Book Not Found");
            }
            return Ok(book);
        }

        //Update a book through Id
        [HttpPut("{id:int}")]
        public ActionResult<Book> UpdateBook(BookRequestDTO book, int id)
        {
            var _book = _dbContext.Books.Find(id);//means Unchange tracking is on
            if (_book == null)
            {
                return NotFound("Book Not Found");
            }

            _book.Title = book.Title;
            _book.Author = book.Author;
            _book.Description = book.Description;
            _book.Price = book.Price;

            _dbContext.SaveChanges();//now data is modified and persisted also

            return Ok(_book);
        }

        //Delete a book through Id
        [HttpDelete("{id:int}")]
        public ActionResult<Book> DeleteBook(int id)
        {
            var _book = _dbContext.Books.Find(id);//means Unchange tracking is on
            if (_book == null)
            {
                return NotFound("Book Not Found");
            }

            _dbContext.Books.Remove(_book);//means data is remove in memory
            _dbContext.SaveChanges();//now data is persisted

            return NoContent();
        }
    }
}
/**
 * States in Entity Framework
 * There are five states in EF
 * 1) Added
 * 2) Modified
 * 3) Unchanged
 * 4) Deleted
 * 5) Detached
 */