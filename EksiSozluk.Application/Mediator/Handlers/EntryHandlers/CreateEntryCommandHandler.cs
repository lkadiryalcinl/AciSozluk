using EksiSozluk.Application.Interfaces;
using EksiSozluk.Application.Mediator.Commands.EntryCommands;
using EksiSozluk.Domain.Entities;
using MediatR;

namespace EksiSozluk.Application.Mediator.Handlers.EntryHandlers
{
    internal class CreateEntryCommandHandler : IRequestHandler<CreateEntryCommand>
    {
        private readonly IRepository<Entry> _repository;

        public CreateEntryCommandHandler(IRepository<Entry> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateEntryCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Entry
            {
                CreatedDate = DateTime.UtcNow,
                DeletedDate = DateTime.MinValue,
                UpdatedDate = DateTime.MinValue,
                IsEntryDelete = false,
                IsEntryUpdated = false,
                TitleId = request.TitleId,
                UserId = request.UserId,
                EntryContent = request.EntryContent,
                
            });
        }
    }
}
