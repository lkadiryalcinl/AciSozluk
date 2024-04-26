using EksiSozluk.Application.Interfaces.TopicInterfaces;
using EksiSozluk.Application.Mediator.Queries.TitleQueries;
using EksiSozluk.Application.Mediator.Results.TitleResults;
using MediatR;

namespace EksiSozluk.Application.Mediator.Handlers.TitleHandlers
{
    internal class GetTitleByFilterQueryHandler : IRequestHandler<GetTitleByFilterQuery, List<GetTitleByFilterQueryResult>>
    {
        private readonly ITopicRepository _topicRepository;

        public GetTitleByFilterQueryHandler(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<List<GetTitleByFilterQueryResult>> Handle(GetTitleByFilterQuery request, CancellationToken cancellationToken)
        {
            var values = await _topicRepository.GetByFilterAsync(x => x.Channel.ChannelName ==  request.ChannelName);
            var results = values.Select(y => new GetTitleByFilterQueryResult
            {
                Id = y.Id,
                TitleName = y.TitleName
            }).ToList();
            return results;
        }
    }
}
