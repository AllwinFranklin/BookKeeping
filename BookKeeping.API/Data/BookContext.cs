using BookKeeping.API.Model;
using Microsoft.EntityFrameworkCore;

namespace BookKeeping.API.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Citation> Citations { get; set; }
    }
}
