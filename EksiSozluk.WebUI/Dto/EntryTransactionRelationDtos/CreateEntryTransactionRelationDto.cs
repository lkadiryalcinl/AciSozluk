namespace EksiSozluk.WebUI.Dto.EntryTransactionRelationDtos
{
    public class CreateEntryTransactionRelationDto
    {
        public Guid EntryTransactionId { get; set; }
        public Guid EntryId { get; set; }
        public string UserId { get; set; }
        public DateTime FavoritedDate { get; set; }
        public DateTime LikedDate { get; set; }
        public DateTime DisikedDate { get; set; }
        public bool IsFavorited { get; set; }
        public bool IsLiked { get; set; }
        public bool IsDisliked { get; set; }
    }
}