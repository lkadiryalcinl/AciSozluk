namespace EksiSozluk.Domain.Entities
{
    public class FollowUser
    {
        public Guid Id { get; set; }
        public string FollowingId { get; set; }
        public User Following { get; set; }
        public string FollowedId { get; set; }
    }
}
