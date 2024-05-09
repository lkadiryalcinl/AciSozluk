using EksiSozluk.Application.Mediator.Queries.EntryQueries;
using EksiSozluk.Application.Mediator.Queries.EntryTransactionQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryTransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EntryTransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetEntryTransactionsByFilter")]
        public async Task<IActionResult> GetEntriesByFilter(string id)
        {
            GetEntryTransactionQuery getEntryTransactionQuery = new()
            {
                Id = id
            };
            var values = await _mediator.Send(getEntryTransactionQuery);
            return Ok(values);
        }
    }
}
