using EksiSozluk.Application.Interfaces;
using EksiSozluk.Application.Mediator.Commands.ProfileEntryCommands;
using EksiSozluk.Domain.Entities;
using MediatR;

namespace EksiSozluk.Application.Mediator.Handlers.ProfileEntryHandlers
{
    internal class UpdateProfileEntryCommandHandler : IRequestHandler<UpdateProfileEntryCommand>
    {
        private readonly IRepository<Entry> _repository;

        public UpdateProfileEntryCommandHandler(IRepository<Entry> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateProfileEntryCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(x => x.Id ==  request.Id);
            value.IsEntryUpdated = true;
            value.UpdatedDate = DateTime.Now;
            value.EntryContent = request.EntryContent;
            await _repository.UpdateAsync(value);
        }
    }
}
