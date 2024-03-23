namespace EksiSozluk.Domain.Entities
{
    public class FollowChannel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public Guid ChannelId { get; set; }
        public Channel Channel { get; set; }
    }
}
