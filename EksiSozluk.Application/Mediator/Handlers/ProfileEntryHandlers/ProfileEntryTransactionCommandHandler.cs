using EksiSozluk.Application.Interfaces;
using EksiSozluk.Application.Mediator.Commands.Profile;
using EksiSozluk.Domain.Entities;
using MediatR;

namespace EksiSozluk.Application.Mediator.Handlers.ProfileEntryHandlers
{
    public class ProfileEntryTransactionCommandHandler : IRequestHandler<RemoveProfileEntryCommand>
    {

        private readonly IRepository<Entry> repository;

        public ProfileEntryTransactionCommandHandler(IRepository<Entry> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemoveProfileEntryCommand request, CancellationToken cancellationToken)
        {
            var value = await repository.GetByIdAsync(request.Id);
            value.IsEntryDelete = true;
            await repository.UpdateAsync(value);
        }

    }
}
