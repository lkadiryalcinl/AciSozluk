using EksiSozluk.Application.Mediator.Results.FollowChannelResults;
using MediatR;

namespace EksiSozluk.Application.Mediator.Queries.FollowChannelQueries
{
    public class GetFollowChannelByFilterQuery : IRequest<List<GetFollowChannelsByFilterQueryResult>>
    {
        public string UserId { get; set; }
    }
}
