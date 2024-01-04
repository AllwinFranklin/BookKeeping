
using BookKeeping.API.Model;
using Microsoft.EntityFrameworkCore;

namespace BookKeeping.API.Data
{
    public class BookContextSeed
    {
        public static async Task SeedAsync(BookContext bookContext, ILogger<BookContextSeed> logger)
        {
            if (!bookContext.Books.Any())
            {
                bookContext.Books.AddRange(GetPreconfiguredBooks());
                await bookContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName} for Book table", typeof(BookContext).Name);
            }
            if (!bookContext.Citations.Any())
            {
                bookContext.Citations.AddRange(GetPreconfiguredCitations(bookContext.Books.ToList()));
                await bookContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName} for Citation table", typeof(BookContext).Name);
            }
        }

        private static IEnumerable<Book> GetPreconfiguredBooks()
        {
            return new List<Book>
            {
                new Book()
                {
                    AuthorFirstName = "David",
                    AuthorLastName = "Selvan",
                    Title = "The Creative book",
                    Publisher = "Times Now",
                    Price = 10
                },
                new Book()
                {
                    AuthorFirstName = "Allwin",
                    AuthorLastName = "Franklin",
                    Title = "The first book",
                    Publisher = "B.S.I",
                    Price = 10
                },
                new Book()
                {
                    AuthorFirstName = "Alex",
                    AuthorLastName = "Jeffrin",
                    Title = "The unknown",
                    Publisher = "Bloom India",
                    Price = 10
                },
                new Book()
                {
                    AuthorFirstName = "Nig",
                    AuthorLastName = "Zeus",
                    Title = "The All rounder book",
                    Publisher = "Bloom India",
                    Price = 10
                }
            };
        }
        private static IEnumerable<Citation> GetPreconfiguredCitations(List<Book> books)
        {
            return new List<Citation>
            {
                new Citation()
                {
                    Book = books[0],
                    SourceTitle = "Sample Chapter title",
                    VolumeNo = 3,
                    StartPageNo = 125,
                    EndPageNo = 127,
                    URL = "github.com/bookTitle"
                },
                new Citation()
                {
                    Book = books[1],
                    SourceTitle = "Sample Chapter title 4",
                    VolumeNo = 2,
                    StartPageNo = 155,
                    EndPageNo = 162,
                    URL = "github.com/bookTitle4"
                },
                new Citation()
                {
                    Book = books[3],
                    SourceTitle = "Sample Chapter title 2",
                    VolumeNo = 1,
                    StartPageNo = 12,
                    EndPageNo = 18,
                    URL = "github.com/bookTitle2"
                }
            };
        }
    }
}
