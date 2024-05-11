using EksiSozluk.Application.Interfaces.EntryTransactionRelationInterfaces;
using EksiSozluk.Application.Mediator.Queries.EntryTransactionRelationQueries;
using EksiSozluk.Application.Mediator.Results.EntryTransactionRelationResults;
using MediatR;

namespace EksiSozluk.Application.Mediator.Handlers.EntryTransactionRelationHandlers
{
    internal class GetEntryTransactionRelationQueryHandler : IRequestHandler<GetEntryTransactionRelationQuery, GetEntryTransactionRelationQueryResult>
    {
        private readonly IEntryTransactionRelationRepository _entryTransactionRelationRepository;

        public GetEntryTransactionRelationQueryHandler(IEntryTransactionRelationRepository entryTransactionRelationRepository)
        {
            _entryTransactionRelationRepository = entryTransactionRelationRepository;
        }

        public async Task<GetEntryTransactionRelationQueryResult> Handle(GetEntryTransactionRelationQuery request, CancellationToken cancellationToken)
        {
            var values = await _entryTransactionRelationRepository.GetByFilterAsync(x => x.UserId == request.UserId && x.EntryId == request.EntryId);

            return new GetEntryTransactionRelationQueryResult
            {
                EntryTransactionId = values.EntryTransactionId.ToString().ToUpper(),
                Id = values.Id
            };
        }
    }
}
