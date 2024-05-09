using EksiSozluk.Application.Mediator.Results.EntryTransactionResults;
using MediatR;

namespace EksiSozluk.Application.Mediator.Queries.EntryTransactionQueries
{
    public class GetEntryTransactionQuery : IRequest<GetEntryTransactionQueryResult>
    {
        public string Id { get; set; }
    }
}
