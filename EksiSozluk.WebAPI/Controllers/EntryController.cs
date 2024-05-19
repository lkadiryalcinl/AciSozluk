using EksiSozluk.Application.Mediator.Commands.EntryTransactionCommands;
using EksiSozluk.Application.Mediator.Commands.Profile;
using EksiSozluk.Application.Mediator.Queries.EntryQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EntryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetEntriesByFilter")]
        public async Task<IActionResult> GetEntriesByFilter(string id)
        {
            GetEntriesByFilterQuery getEntriesByFilterQuery = new()
            {
                Id = id
            };
            var values = await _mediator.Send(getEntriesByFilterQuery);
            return Ok(values);
        }


        [HttpPut("ProfileEntryRemove")]
        public async Task<IActionResult> UpdateEntryTransaction(Guid id)
        {
            RemoveProfileEntryCommand profileEntryDeleteCommand = new();
            profileEntryDeleteCommand.Id = id;
            await _mediator.Send(profileEntryDeleteCommand);
            return Ok();
        }

    }
}
