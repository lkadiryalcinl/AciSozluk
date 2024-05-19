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
        
        [HttpGet("GetFollowChannelsByFilter")]
        public async Task<IActionResult> UnfollowChannel(string userId)
        {
            GetFollowChannelByFilterQuery query = new()
            {
                UserId = userId
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

        [HttpDelete("UnfollowChannel")]
        public async Task<IActionResult> UnfollowChannel(Guid channelId,string userId)
        {
            RemoveFollowChannelCommand command = new()
            {
                ChannelId = channelId,
                UserId = userId
            };
            await _mediator.Send(command);
            return Ok("Success");
        }
    }
}
