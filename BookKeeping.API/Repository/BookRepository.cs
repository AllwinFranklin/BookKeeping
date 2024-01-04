using BookKeeping.API.Contracts;
using BookKeeping.API.Data;
using BookKeeping.API.Model;
using Microsoft.EntityFrameworkCore;

namespace BookKeeping.API.Repository
{
    public class BookRepository : IBookRepository
    {
        protected readonly BookContext _dbContext;

        public BookRepository(BookContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Book>> GetAllBooksSortByAurthorTitle()
        {
            var books = await _dbContext.Books
                .OrderBy(x => x.AuthorLastName)
                .ThenBy(x => x.AuthorFirstName)
                .ThenBy(x => x.Title)
                .ToListAsync();
            return books;
        }

        public async Task<IEnumerable<Book>> GetAllBooksSortByAurthorTitleSP()
        {
            return await _dbContext.Books
                .FromSqlRaw("GetAllBooksSortByAurthorTitleSP")
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllBooksSortByPublisherAurthorTitle()
        {
            var books = await _dbContext.Books
                .OrderBy(x => x.Publisher)
                .ThenBy(x => x.AuthorLastName)
                .ThenBy(x => x.AuthorFirstName)
                .ThenBy(x => x.Title)
                .ToListAsync();
            return books;
        }

        public async Task<IEnumerable<Book>> GetAllBooksSortByPublisherAurthorTitleSP()
        {
            return await _dbContext.Books
                .FromSqlRaw("GetAllBooksSortByPublisherAurthorTitleSP")
                .ToListAsync();
        }

        public async Task<decimal> GetTotalBookPrice()
        {
            var total = await _dbContext.Books
                .SumAsync(x => x.Price);

            return total;
        }
    }
}
