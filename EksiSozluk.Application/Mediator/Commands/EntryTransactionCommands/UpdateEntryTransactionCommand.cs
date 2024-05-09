﻿using MediatR;

namespace EksiSozluk.Application.Mediator.Commands.EntryTransactionCommands
{
    public class UpdateEntryTransactionCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid EntryTransactionRelationId { get; set; }
        public DateTime FavoritedDate { get; set; }
        public DateTime LikedDate { get; set; }
        public DateTime DisikedDate { get; set; }
        public bool IsFavorited { get; set; }
        public bool IsLiked { get; set; }
        public bool IsDisliked { get; set; }
    }
}
