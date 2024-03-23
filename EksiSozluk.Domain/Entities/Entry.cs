namespace EksiSozluk.Domain.Entities
{
    public class Entry
    {
        public Guid Id { get; set; }

        public string EntryContent { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime DeletedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool IsEntryDelete { get; set; } = false;

        public bool IsEntryUpdated { get; set; } = false;

        // Entry has to belong to one user
        // Followed Entry list belong to one user
        public string UserId { get; set; }

        public User User { get; set; }
        // Entry has to belong to one title
        public Guid TitleId { get; set; }

        public Title Title { get; set; }
        public List<EntryTransactionRelation> EntryTransactionRelations { get; set; }
    }
}
