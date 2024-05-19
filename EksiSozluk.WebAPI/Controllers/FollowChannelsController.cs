using EksiSozluk.Application.Mediator.Commands.FollowChannelCommands;
using EksiSozluk.Application.Mediator.Queries.FollowChannelQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowChannelsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FollowChannelsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost("GetfollowChannelsByFilter")]
        public async Task<IActionResult> UnfollowChannel(string UserId)
        {
            GetFollowChannelByFilterQuery query = new()
            {
                UserId = UserId
            };
            var values = await _mediator.Send(query);
            return Ok(values);
        }

        [HttpPost("FollowChannel")]
        public async Task<IActionResult> FollowChannel(CreateFollowChannelCommand createFollowChannelCommand)
        {
            await _mediator.Send(createFollowChannelCommand);
            return Ok("Success");
        }

        [HttpPost("UnfollowChannel")]
        public async Task<IActionResult> UnfollowChannel(RemoveFollowChannelCommand removeFollowChannelCommand)
        {
            await _mediator.Send(removeFollowChannelCommand);
            return Ok("Success");
        }
    }
}
