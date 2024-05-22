using EksiSozluk.Application.Dtos.EntryDtos;
using EksiSozluk.Application.Interfaces.TopicInterfaces;
using EksiSozluk.Application.Mediator.Queries.TitleQueries;
using EksiSozluk.Application.Mediator.Results.TitleResults;
using EksiSozluk.Domain.Entities;
using MediatR;



namespace EksiSozluk.Application.Mediator.Handlers.TitleHandlers
{
    internal class GetTitlesByFilterWithFirstEntryQueryHandler : IRequestHandler<GetTitlesByFilterWithFirstEntryQuery, List<GetTitlesByFilterWithFirstEntryQueryResult>>
    {
        private readonly ITopicRepository _topicRepository;

        public GetTitlesByFilterWithFirstEntryQueryHandler(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<List<GetTitlesByFilterWithFirstEntryQueryResult>> Handle(GetTitlesByFilterWithFirstEntryQuery request, CancellationToken cancellationToken)
        {
            List<Title> values = new();
            //|| request.ChannelName != "çaylaklar" || request.ChannelName != "takip"
            if (request.Id == "debe")
            {
                values = await _topicRepository.GetByTopLikedEntriesFromYesterdayAsync();
            }
            else if (request.Id == "gündem")
            {
                values = await _topicRepository.GetByDailyEntryCountAsync();
            }
            else if (request.Id == "bugün")
            {
                values = await _topicRepository.GetByLastEntryAsync();
            }
            else
            {
                values = await _topicRepository.GetByFilterWithFirstEntryAsync(x => x.Channel.Id.ToString() == request.Id || x.Channel.ChannelName == request.Id);
            }


            var results = values.Select(x => new GetTitlesByFilterWithFirstEntryQueryResult
            {
                Id = x.Id,
                TitleName = x.TitleName,
                ChannelName = x.Channel.ChannelName,
                FirstEntry = x.Entries.Select(x => new EntryWithoutTitleInfoDto
                {
                    Id = x.Id,
                    CreatedDate = x.CreatedDate,
                    DeletedDate = x.DeletedDate,
                    EntryContent = x.EntryContent,
                    IsEntryDelete = x.IsEntryDelete,
                    IsEntryUpdated = x.IsEntryUpdated,
                    UpdatedDate = x.UpdatedDate,
                    Username = x.User.UserName,
                    FavoritedCount = x.EntryTransactionRelations?
                    .Where(y => y.EntryId == x.Id && y.EntryTransaction.IsFavorited)
                    .Count()
                    ?? 0,
                    IsFavByUser = x.EntryTransactionRelations?
                    .Any(y => y.UserId == x.User.Id && y.EntryTransaction.IsFavorited) ?? false,
                    IsLikedByUser = x.EntryTransactionRelations?
                .Any(y => y.UserId == x.User.Id && y.EntryTransaction.IsLiked) ?? false,
                    IsDislikedByUser = x.EntryTransactionRelations?
                .Any(y => y.UserId == x.User.Id && y.EntryTransaction.IsDisliked) ?? false,
                }).OrderBy(x => x.CreatedDate).FirstOrDefault()
            }).ToList();

            return results;
        }
    }
}