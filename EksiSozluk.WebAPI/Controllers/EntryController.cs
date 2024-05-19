using EksiSozluk.Application.Mediator.Commands.EntryCommands;
using EksiSozluk.Application.Mediator.Commands.ProfileEntryCommands;
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
            RemoveProfileEntryCommand profileEntryDeleteCommand = new()
            {
                Id = id
            };

            await _mediator.Send(profileEntryDeleteCommand);
            return Ok();
        }

        [HttpPut("UpdateProfileEntry")]
        public async Task<IActionResult> UpdateEntryTransactionContent(UpdateProfileEntryCommand updateProfileEntryCommand)
        {
            await _mediator.Send(updateProfileEntryCommand);
            return Ok();
        }

        [HttpPost("CreateEntry")]
        public async Task<IActionResult> CreateEntryTransaction(CreateEntryCommand createEntryCommand)
        {
            await _mediator.Send(createEntryCommand);
            return Ok();
        }

    }
}
