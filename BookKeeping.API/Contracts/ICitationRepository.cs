using BookKeeping.API.Model;

namespace BookKeeping.API.Contracts
{
    public interface ICitationRepository
    {
        Task<IEnumerable<string>> getAllBooksMLACitation();
        Task<IEnumerable<string>> getAllBooksChicagoCitation();
    }
}
