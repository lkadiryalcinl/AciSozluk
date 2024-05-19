using EksiSozluk.Application.Interfaces.FollowChannelInterfaces;
using EksiSozluk.Application.Mediator.Queries.FollowChannelQueries;
using EksiSozluk.Application.Mediator.Results.FollowChannelResults;
using MediatR;

namespace EksiSozluk.Application.Mediator.Handlers.FollowChannelHandlers
{
    internal class GetFollowChannelsByFilterQueryHandler : IRequestHandler<GetFollowChannelByFilterQuery, List<GetFollowChannelsByFilterQueryResult>>
    {
        private readonly IFollowChannelRepository _repository;

        public GetFollowChannelsByFilterQueryHandler(IFollowChannelRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFollowChannelsByFilterQueryResult>> Handle(GetFollowChannelByFilterQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByFilterAsync(x => x.UserId == request.UserId);
            var results = values.Select(y => new GetFollowChannelsByFilterQueryResult
            {
                ChannelId = y.ChannelId,
                FollowedDate = y.FollowedDate
            }).ToList();

            return results;
        }

    }
}
