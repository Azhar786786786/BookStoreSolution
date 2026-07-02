using BookStoreWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
    }
}
