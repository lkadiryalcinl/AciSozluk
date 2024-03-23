namespace EksiSozluk.Domain.Entities
{
    public class Title
    {
        public Guid Id { get; set; }

        public string TitleName { get; set; }

        public bool IsFollowed { get; set; } = false;

        // the title has to belong one user 
        public string UserId { get; set; }

        public User User { get; set; }
        // the title has to belong one channel
        public Guid ChannelId { get; set; }

        public Channel Channel { get; set; }
        // the title can have many entries
        public ICollection<Entry> Entries { get; set; }
    }
}
