using EksiSozluk.Application.Dtos.EntryDtos;
using EksiSozluk.Application.Interfaces.EntryInterfaces;
using EksiSozluk.Application.Mediator.Queries.EntryQueries;
using EksiSozluk.Application.Mediator.Results.EntryResults;
using MediatR;

namespace EksiSozluk.Application.Mediator.Handlers.EntryHandlers
{
    public class GetEntryByFilterQueryHandler : IRequestHandler<GetEntriesByFilterQuery, List<GetEntriesByFilterQueryResult>>
    {
        private readonly IEntryRepository _entryRepository;

        public GetEntryByFilterQueryHandler(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

        public async Task<List<GetEntriesByFilterQueryResult>> Handle(GetEntriesByFilterQuery request, CancellationToken cancellationToken)
        {

            var values = await _entryRepository.GetByFilterAsync(x => x.UserId == request.Id || x.User.UserName == request.Id);

            return values.Select(x => new GetEntriesByFilterQueryResult
            {
                Id = x.Id,
                TitleName = x.Title.TitleName,
                CreatedDate = x.CreatedDate,
                EntryContent = x.EntryContent,        
            }).ToList();
          



        }
    }
}
