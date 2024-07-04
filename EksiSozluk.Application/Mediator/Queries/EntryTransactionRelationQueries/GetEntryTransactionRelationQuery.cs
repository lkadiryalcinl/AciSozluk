using EksiSozluk.Application.Mediator.Results.EntryTransactionRelationResults;
using MediatR;

namespace EksiSozluk.Application.Mediator.Queries.EntryTransactionRelationQueries
{
    public class GetEntryTransactionRelationQuery : IRequest<GetEntryTransactionRelationQueryResult>
    {
        public string UserId { get; set; }
        public Guid EntryId { get; set; }
    }
}
