using EksiSozluk.Application.Mediator.Results.ProfileEntryResults;
using MediatR;

namespace EksiSozluk.Application.Mediator.Queries.EntryQueries
{
    public class GetEntryByFilterQuery : IRequest<GetEntryByFilterQueryResult>
    {
        public Guid Id { get; set; }
    }
}
