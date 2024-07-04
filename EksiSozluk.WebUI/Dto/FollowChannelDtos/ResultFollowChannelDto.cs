namespace EksiSozluk.WebUI.Dto.FollowChannelDtos
{
    public class ResultFollowChannelDto
    {
        public Guid Id { get; set; }
        public Guid ChannelId { get; set; }
        public DateTime FollowedDate { get; set; }
    }
}
