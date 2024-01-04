
using BookKeeping.API.Model;

namespace BookKeeping.API.Data
{
    public class BookContextSeed
    {
        public static async Task SeedAsync(BookContext bookContext, ILogger<BookContextSeed> logger)
        {
            if (!bookContext.Books.Any())
            {
                bookContext.Books.AddRange(GetPreconfiguredOrders());
                await bookContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(BookContext).Name);
            }
        }

        private static IEnumerable<Book> GetPreconfiguredOrders()
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
    }
}
