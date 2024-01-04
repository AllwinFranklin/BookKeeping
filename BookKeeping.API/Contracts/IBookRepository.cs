using BookKeeping.API.Model;

namespace BookKeeping.API.Contracts
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksSortByPublisherAurthorTitle();
        Task<IEnumerable<Book>> GetAllBooksSortByAurthorTitle();
        Task<IEnumerable<Book>> GetAllBooksSortByPublisherAurthorTitleSP();
        Task<IEnumerable<Book>> GetAllBooksSortByAurthorTitleSP();
        Task<decimal> GetTotalBookPrice();
    }
}
