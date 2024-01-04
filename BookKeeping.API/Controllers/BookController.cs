using BookKeeping.API.Contracts;
using BookKeeping.API.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookKeeping.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/")]
    public class BookController : Controller
    {
        private readonly IBookRepository _repository;

        public BookController(IBookRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("BooksSortByPublisher", Name = "GetAllBooksSortByPublisher")]
        [ProducesResponseType(typeof(IEnumerable<Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooksSortByPublisherAurthorTitle()
        {
            var books = await _repository.GetAllBooksSortByPublisherAurthorTitle();
            return Ok(books);
        }
        [HttpGet("BooksSortByPublisherSP", Name = "GetAllBooksSortByPublisherSP")]
        [ProducesResponseType(typeof(IEnumerable<Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooksSortByPublisherAurthorTitleSP()
        {
            var books = await _repository.GetAllBooksSortByPublisherAurthorTitleSP();
            return Ok(books);
        }

        [HttpGet("BooksSortByAuthor", Name = "GetAllBooksSortByAuthor")]
        [ProducesResponseType(typeof(IEnumerable<Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooksSortByAuthor()
        {
            var books = await _repository.GetAllBooksSortByAurthorTitle();
            return Ok(books);
        }

        [HttpGet("BooksSortByAuthorSP", Name = "GetAllBooksSortByAuthorSP")]
        [ProducesResponseType(typeof(IEnumerable<Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooksSortByAuthorSP()
        {
            var books = await _repository.GetAllBooksSortByAurthorTitleSP();
            return Ok(books);
        }

        [HttpGet("TotalBookPrice", Name = "GetTotalBookPrice")]
        [ProducesResponseType(typeof(decimal), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<decimal>> GetTotalBookPrice()
        {
            var totalPrice = await _repository.GetTotalBookPrice();
            return Ok(totalPrice);
        }
    }
}
