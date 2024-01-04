using BookKeeping.API.Contracts;
using BookKeeping.API.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookKeeping.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/")]
    public class CitationController : Controller
    {
        private readonly ICitationRepository _repository;

        public CitationController(ICitationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("MLACitation", Name = "MLACitation")]
        [ProducesResponseType(typeof(IEnumerable<string>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<string>>> MLACitation()
        {
            var books = await _repository.getAllBooksMLACitation();
            return Ok(books);
        }
        [HttpGet("ChicagoCitation", Name = "ChicagoCitation")]
        [ProducesResponseType(typeof(IEnumerable<string>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<string>>> ChicagoCitation()
        {
            var books = await _repository.getAllBooksChicagoCitation();
            return Ok(books);
        }
    }
}
