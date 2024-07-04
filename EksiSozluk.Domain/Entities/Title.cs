namespace EksiSozluk.Domain.Entities
{
    public class Title
    {
        public Guid Id { get; set; }

        public string TitleName { get; set; }
        public Guid ChannelId { get; set; }
        public Channel Channel { get; set; }
        // The title can have many entries
        public FollowTitle FollowTitle { get; set; }
        public List<Entry> Entries { get; set; }
    }
}
