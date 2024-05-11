using EksiSozluk.Application.Interfaces;
using EksiSozluk.Application.Mediator.Commands.EntryTransactionCommands;
using EksiSozluk.Domain.Entities;
using MediatR;

namespace EksiSozluk.Application.Mediator.Handlers.EntryTransactionHandlers
{
    internal class UpdateEntryTransactionCommandHandler : IRequestHandler<UpdateEntryTransactionCommand>
    {
        private readonly IRepository<EntryTransaction> _repository;

        public UpdateEntryTransactionCommandHandler(IRepository<EntryTransaction> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateEntryTransactionCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id.ToString());
            value.FavoritedDate = request.FavoritedDate;
            value.IsFavorited = request.IsFavorited;
            value.LikedDate = request.LikedDate;
            value.IsLiked = request.IsLiked;
            value.DisikedDate = request.DisikedDate;
            value.IsDisliked = request.IsDisliked;

            await _repository.UpdateAsync(value);
        }
    }
}
