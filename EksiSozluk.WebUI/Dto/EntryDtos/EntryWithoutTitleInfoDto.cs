namespace EksiSozluk.Application.Dtos.EntryDtos
{
    public class EntryWithoutTitleInfoDto
    {
        public Guid Id { get; set; }
        public string EntryContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsEntryDelete { get; set; } = false;
        public bool IsEntryUpdated { get; set; } = false;
        public string Username { get; set; }
        public int FavoritedCount { get; set; }
        public bool IsFavByUser { get; set; }
        public bool IsLikedByUser { get; set; }
        public bool IsDislikedByUser { get; set; }
    }
}
