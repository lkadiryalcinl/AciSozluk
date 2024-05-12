using EksiSozluk.Application.Mediator.Results.EntryTransactionResults;
using MediatR;

namespace EksiSozluk.Application.Mediator.Queries.EntryTransactionQueries
{
    public class GetEntryTransactionQuery : IRequest<GetEntryTransactionQueryResult>
    {
        public Guid Id { get; set; }
    }
}
