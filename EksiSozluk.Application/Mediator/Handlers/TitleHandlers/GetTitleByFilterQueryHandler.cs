using EksiSozluk.Application.Interfaces.TopicInterfaces;
using EksiSozluk.Application.Mediator.Queries.TitleQueries;
using EksiSozluk.Application.Mediator.Results.TitleResults;
using EksiSozluk.Domain.Entities;
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
            List<Title> values = new();
            //|| request.ChannelName != "çaylaklar" || request.ChannelName != "takip"
            if (request.ChannelName == "debe")
            {
                values = await _topicRepository.GetByTopLikedEntriesFromYesterdayAsync();
            }
            else if (request.ChannelName == "gündem")
            {
                values = await _topicRepository.GetByDailyEntryCountAsync();
            }
            else if (request.ChannelName == "bugün")
            {
                values = await _topicRepository.GetByLastEntryAsync();
            }
            else
            {
                values = await _topicRepository.GetByFilterAsync(x => x.Channel.ChannelName == request.ChannelName);
            }

            var results = values.Select(y => new GetTitleByFilterQueryResult
            {
                Id = y.Id,
                TitleName = y.TitleName,
                ChannelName = y.Channel.ChannelName,
                EntryCount = y.Entries.Count
            }).ToList();
            return results;
        }
    }
}
