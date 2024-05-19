using MediatR;

namespace EksiSozluk.Application.Mediator.Commands.ProfileEntryCommands
{
    public class UpdateProfileEntryCommand : IRequest
    {
        public Guid Id { get; set; }
        public string EntryContent { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsEntryUpdated { get; set; } = false;
    }
}
