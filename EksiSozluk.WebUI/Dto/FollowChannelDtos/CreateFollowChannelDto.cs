using EksiSozluk.Domain.Entities;

namespace EksiSozluk.WebUI.Dto.FollowChannelDtos
{
    public class CreateFollowChannelDto
    {
        public string UserId { get; set; }
        public Guid ChannelId { get; set; }
        public DateTime FollowDate { get; set; }
    }
}
