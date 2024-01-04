using BookKeeping.API.Contracts;
using BookKeeping.API.Data;
using BookKeeping.API.Model;
using Microsoft.EntityFrameworkCore;

namespace BookKeeping.API.Repository
{
    public class CitationRepository : ICitationRepository
    {
        protected readonly BookContext _dbContext;

        public CitationRepository(BookContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<string>> getAllBooksMLACitation()
        {
            var citations = await _dbContext.Citations
                .Include(c => c.Book)
                .Select(c => $"{c.Book.AuthorLastName}, {c.Book.AuthorFirstName}. \"{c.SourceTitle}\"\n {c.Book.Title}, {c.Book.Publisher}, {c.Book.PublishedDate.Year}, pp. {c.StartPageNo}-{c.EndPageNo}.")
                .ToListAsync();
            return citations;
        }

        public async Task<IEnumerable<string>> getAllBooksChicagoCitation()
        {
            var citations = await _dbContext.Citations
                .Include(c => c.Book)
                .Select(c => $"{c.Book.AuthorLastName}, {c.Book.AuthorFirstName}. {c.Book.PublishedDate.Year}: \"{c.Book.Title}\" {c.SourceTitle}. no. {c.VolumeNo} ({c.Book.PublishedDate.ToString("MMMM")} {c.Book.PublishedDate.Year}) {c.Book.Publisher}. {c.StartPageNo}-{c.EndPageNo}. {c.URL}")
                .ToListAsync();
            return citations;
        }
    }
}
