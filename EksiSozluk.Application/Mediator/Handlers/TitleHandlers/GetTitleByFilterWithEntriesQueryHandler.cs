using EksiSozluk.Application.Dtos.EntryDtos;
using EksiSozluk.Application.Interfaces.TopicInterfaces;
using EksiSozluk.Application.Mediator.Queries.TitleQueries;
using EksiSozluk.Application.Mediator.Results.TitleResults;
using EksiSozluk.Domain.Entities;
using MediatR;

namespace EksiSozluk.Application.Mediator.Handlers.TitleHandlers
{
    internal class GetTitleByFilterWithEntriesQueryHandler : IRequestHandler<GetTitleByFilterWithEntriesQuery, GetTitleByFilterWithEntriesQueryResult>
    {
        private readonly ITopicRepository _topicRepository;

        public GetTitleByFilterWithEntriesQueryHandler(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<GetTitleByFilterWithEntriesQueryResult> Handle(GetTitleByFilterWithEntriesQuery request, CancellationToken cancellationToken)
        {
            var values = await _topicRepository.GetByFilterWithEntriesAsync(x => x.Id.ToString() == request.Id || x.TitleName == request.Id);

            var entryDtoList = values.Entries.Select(x => new EntryWithoutTitleInfoDto
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
            }).OrderBy(x => x.CreatedDate).ToList();

            return new GetTitleByFilterWithEntriesQueryResult
            {
                Id = values.Id,
                TitleName = values.TitleName,
                EntryList = entryDtoList
            };
        }
    }
}