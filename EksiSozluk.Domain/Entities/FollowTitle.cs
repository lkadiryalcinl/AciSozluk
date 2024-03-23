namespace EksiSozluk.Domain.Entities
{
    public class FollowTitle
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public Guid TitleId { get; set; }
        public Title Title { get; set; }
    }
}
