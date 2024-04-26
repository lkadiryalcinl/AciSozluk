using EksiSozluk.Application.Mediator.Queries.TitleQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitlesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TitlesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetRentACarListByLocation(string channelName)
        {
            GetTitleByFilterQuery getTitleByFilterQuery = new()
            {
                ChannelName = channelName
            };
            var values = await _mediator.Send(getTitleByFilterQuery);
            return Ok(values);
        }
    }
}
