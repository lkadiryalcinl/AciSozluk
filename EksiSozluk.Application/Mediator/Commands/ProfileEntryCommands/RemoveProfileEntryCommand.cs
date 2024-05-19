using MediatR;

namespace EksiSozluk.Application.Mediator.Commands.ProfileEntryCommands
{
    public class RemoveProfileEntryCommand : IRequest
    {
        public Guid Id { get; set; }
        public bool IsEntryDelete { get; set; } = false;
    }
}
