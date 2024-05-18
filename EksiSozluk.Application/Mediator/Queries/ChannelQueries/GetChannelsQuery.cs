using EksiSozluk.Application.Mediator.Results.ChannelResults;
using MediatR;

namespace EksiSozluk.Application.Mediator.Queries.ChannelQueries
{
    public class GetChannelsQuery : IRequest<List<GetChannelsQueryResult>>
    {
    }
}
