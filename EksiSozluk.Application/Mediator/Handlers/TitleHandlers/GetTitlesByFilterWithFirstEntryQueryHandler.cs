using EksiSozluk.Application.Dtos.EntryDtos;
using EksiSozluk.Application.Interfaces.TopicInterfaces;
using EksiSozluk.Application.Mediator.Queries.TitleQueries;
using EksiSozluk.Application.Mediator.Results.TitleResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var values = await _topicRepository.GetByFilterWithFirstEntryAsync(x => x.Channel.Id.ToString() == request.Id || x.Channel.ChannelName == request.Id);

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
                    UpdatedDate = x.UpdatedDate
                }).OrderBy(x => x.CreatedDate).FirstOrDefault()
            }).ToList();

            return results;
        }
    }
}
