using MediatR;

namespace EksiSozluk.Application.Mediator.Commands.EntryTransactionRelationCommands
{
    public class CreateEntryTransactionRelationCommand : IRequest
    {
        public Guid EntryTransactionId { get; set; }
        public Guid EntryId { get; set; }
        public string UserId { get; set; }
        public DateTime FavoritedDate { get; set; } = DateTime.MinValue;
        public DateTime LikedDate { get; set; } = DateTime.MinValue;
        public DateTime DisikedDate { get; set; } = DateTime.MinValue;
        public bool IsFavorited { get; set; } = false;
        public bool IsLiked { get; set; } = false;
        public bool IsDisliked { get; set; } = false;
    }
}
