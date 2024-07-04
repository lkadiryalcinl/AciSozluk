using EksiSozluk.Domain.Entities;
using MediatR;

namespace EksiSozluk.Application.Mediator.Commands.EntryCommands
{
    public class CreateEntryCommand : IRequest
    {
        public string EntryContent { get; set; }
        public string UserId { get; set; }
        public Guid TitleId { get; set; }
    }
}
