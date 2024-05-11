using EksiSozluk.Application.Interfaces;
using EksiSozluk.Application.Mediator.Commands.EntryTransactionRelationCommands;
using EksiSozluk.Domain.Entities;
using MediatR;

namespace EksiSozluk.Application.Mediator.Handlers.EntryTransactionRelationHandlers
{
    internal class CreateEntryTransactionRelationCommandHandler : IRequestHandler<CreateEntryTransactionRelationCommand>
    {
        private readonly IRepository<EntryTransactionRelation> _etlrepository;
        private readonly IRepository<EntryTransaction> _etrepository;

        public CreateEntryTransactionRelationCommandHandler(IRepository<EntryTransactionRelation> etlrepository, IRepository<EntryTransaction> etrepository)
        {
            _etlrepository = etlrepository;
            _etrepository = etrepository;
        }

        public async Task Handle(CreateEntryTransactionRelationCommand request, CancellationToken cancellationToken)
        {
            Guid EntryTransactionId = Guid.NewGuid();

            await _etrepository.CreateAsync(new EntryTransaction
            {
                Id = EntryTransactionId,
                DisikedDate = request.DisikedDate,
                FavoritedDate = request.FavoritedDate,
                LikedDate = request.LikedDate,
                IsDisliked = request.IsDisliked,
                IsFavorited = request.IsFavorited,
                IsLiked = request.IsLiked,
            });

            await _etlrepository.CreateAsync(new EntryTransactionRelation
            {
                Id = Guid.NewGuid(),
                EntryTransactionId = EntryTransactionId,
                UserId = request.UserId,
                EntryId = request.EntryId
            });
        }
    }
}
