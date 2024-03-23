namespace EksiSozluk.Domain.Entities
{
    public class Channel
    {
        public Guid Id { get; set; }

        public string ChannelName { get; set; }

        public string ChannelDescription { get; set; }

        public FollowChannel FollowChannel { get; set; }

        public List<Title> Titles { get; set; }

    }
}
