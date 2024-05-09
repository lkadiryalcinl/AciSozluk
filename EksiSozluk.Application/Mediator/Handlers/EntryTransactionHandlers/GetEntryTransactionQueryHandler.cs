using EksiSozluk.Application.Interfaces;
using EksiSozluk.Application.Mediator.Queries.EntryTransactionQueries;
using EksiSozluk.Application.Mediator.Results.EntryTransactionResults;
using EksiSozluk.Domain.Entities;
using MediatR;

namespace EksiSozluk.Application.Mediator.Handlers.EntryTransactionHandlers
{
    internal class GetEntryTransactionQueryHandler : IRequestHandler<GetEntryTransactionQuery, GetEntryTransactionQueryResult>
    {
        private readonly IRepository<EntryTransaction> _repository;

        public GetEntryTransactionQueryHandler(IRepository<EntryTransaction> repository)
        {
            _repository = repository;
        }

        public async Task<GetEntryTransactionQueryResult> Handle(GetEntryTransactionQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);

            return new GetEntryTransactionQueryResult
            {
                DisikedDate = values.DisikedDate,
                IsDisliked = values.IsDisliked,
                FavoritedDate = values.FavoritedDate,
                IsFavorited = values.IsFavorited,
                LikedDate = values.LikedDate,
                IsLiked = values.IsLiked
            };
        }
    }
}
