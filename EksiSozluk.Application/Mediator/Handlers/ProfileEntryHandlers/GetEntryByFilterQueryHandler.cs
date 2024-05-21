using EksiSozluk.Application.Interfaces;
using EksiSozluk.Application.Interfaces.EntryInterfaces;
using EksiSozluk.Application.Mediator.Queries.EntryQueries;
using EksiSozluk.Application.Mediator.Results.ProfileEntryResults;
using EksiSozluk.Domain.Entities;
using MediatR;

namespace EksiSozluk.Application.Mediator.Handlers.ProfileEntryHandlers
{
    internal class GetEntryByFilterQueryHandler : IRequestHandler<GetEntryByFilterQuery, GetEntryByFilterQueryResult>
    {
        private readonly IEntryRepository _repository;

        public GetEntryByFilterQueryHandler(IEntryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetEntryByFilterQueryResult> Handle(GetEntryByFilterQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetSingleByFilterAsync(x => x.Id == request.Id);
            return new GetEntryByFilterQueryResult
            {
                Id = request.Id,
                TitleId = value.TitleId,
                EntryContent = value.EntryContent,
                TitleName = value.Title.TitleName,
                ChannelName = value.Title.Channel.ChannelName,
            };
        }
    }
}
