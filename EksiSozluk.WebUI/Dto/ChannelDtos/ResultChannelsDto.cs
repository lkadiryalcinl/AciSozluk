using EksiSozluk.Domain.Entities;

namespace EksiSozluk.WebUI.Dto.ChannelDtos
{
    public class ResultChannelsDto
    {
        public Guid Id { get; set; }

        public string ChannelName { get; set; }

        public string ChannelDescription { get; set; }
    }
}
