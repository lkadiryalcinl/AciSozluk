namespace EksiSozluk.Domain.Entities
{
    public class Title
    {
        public Guid Id { get; set; }

        public string TitleName { get; set; }

        public bool IsFollowed { get; set; } = false;
        // The followed title list has to belong to one user 
        public string UserId { get; set; }

        public User User { get; set; }
        // The title has to belong to one channel
        public Guid ChannelId { get; set; }

        public Channel Channel { get; set; }
        // The title can have many entries
        public List<Entry> Entries { get; set; }
    }
}
