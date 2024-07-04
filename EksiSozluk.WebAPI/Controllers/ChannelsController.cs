using EksiSozluk.Application.Mediator.Queries.ChannelQueries;
using EksiSozluk.Application.Mediator.Queries.TitleQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChannelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetChannels")]
        public async Task<IActionResult> GetTitleByFilter()
        {
            GetChannelsQuery getChannelsQuery = new();
            var values = await _mediator.Send(getChannelsQuery);
            return Ok(values);
        }
    }
}
