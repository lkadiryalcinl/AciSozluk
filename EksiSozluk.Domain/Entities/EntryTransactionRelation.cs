namespace EksiSozluk.Domain.Entities
{
    public class EntryTransactionRelation
    {
        public Guid Id { get; set; }
        public Guid EntryTransactionId { get; set; }
        public EntryTransaction EntryTransaction { get; set; }
        public Guid EntryId { get; set; }
        public Entry Entry { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
