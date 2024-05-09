using EksiSozluk.Application.Mediator.Commands.EntryTransactionRelationCommands;
using EksiSozluk.Application.Mediator.Queries.EntryTransactionQueries;
using EksiSozluk.Application.Mediator.Queries.EntryTransactionRelationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryTransactionRelationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EntryTransactionRelationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetEntryTransactionRelationByFilter")]
        public async Task<IActionResult> GetEntryTransactionRelationByFilter(string userId,Guid entryId)
        {
            GetEntryTransactionRelationQuery getEntryTransactionRelationQuery = new()
            {
                UserId = userId,
                EntryId = entryId
            };
            var values = await _mediator.Send(getEntryTransactionRelationQuery);
            return Ok(values);
        }

        [HttpPost("CreateEntryTransactionRelation")]
        public async Task<IActionResult> CreateEntryTransactionRelation(CreateEntryTransactionRelationCommand createEntryTransactionRelationCommand)
        {
            await _mediator.Send(createEntryTransactionRelationCommand);
            return Ok("added.");
        }
    }
}
