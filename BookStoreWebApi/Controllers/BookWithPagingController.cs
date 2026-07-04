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
    public class BookWithPagingController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public BookWithPagingController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Fetch all Books Details
        [HttpGet]
        public ActionResult<List<Book>> GetBooks(int pageNumber)
        {
            // var books = _dbContext.Books.ToList();//It is bad practice

            /**var books = _dbContext.Books.ToList();
            var filterBooks = books.Where(x => x.Price > 500);//It is also bad practice
            */
            //var books = _dbContext.Books.Where(book => book.Price > 500);//It is deffered Execution and it is not execution in sql server
            //var books = _dbContext.Books.Where(book => book.Price > 500).ToList();//It is deffered Execution and it is execution in sql server
            var books = _dbContext.Books.Select(book => new BookResponseDTO
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Price = book.Price
            })
                //.OrderBy(book => book.Price)//It is use for sorting
                .Skip(4 * (pageNumber - 1))
                .Take(4)
                .ToList();//It is Projection Execution and it is execution in sql server

            if (books == null)
            {
                return NotFound("Book does not exist.");
            }
            return Ok(books);
        }
    }
}
