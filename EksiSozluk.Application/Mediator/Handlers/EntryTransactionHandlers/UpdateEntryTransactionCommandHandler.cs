using EksiSozluk.Application.Interfaces;
using EksiSozluk.Application.Mediator.Commands.EntryTransactionCommands;
using EksiSozluk.Domain.Entities;
using MediatR;

namespace EksiSozluk.Application.Mediator.Handlers.EntryTransactionHandlers
{
    internal class UpdateEntryTransactionCommandHandler : IRequestHandler<UpdateEntryTransactionCommand>
    {
        private readonly IRepository<EntryTransaction> repository;

        public UpdateEntryTransactionCommandHandler(IRepository<EntryTransaction> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateEntryTransactionCommand request, CancellationToken cancellationToken)
        {
            var value = await repository.GetByIdAsync(x=> x.Id == request.Id);
            value.FavoritedDate = request.FavoritedDate;
            value.IsFavorited = request.IsFavorited;
            value.IsDisliked = request.IsDisliked;
            value.DisikedDate = request.DisikedDate;
            value.LikedDate = request.LikedDate;
            value.IsLiked = request.IsLiked;
            await repository.UpdateAsync(value);
        }
    }
}
