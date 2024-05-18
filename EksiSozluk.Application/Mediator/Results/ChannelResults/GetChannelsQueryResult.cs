using EksiSozluk.Domain.Entities;

namespace EksiSozluk.Application.Mediator.Results.ChannelResults
{
    public class GetChannelsQueryResult
    {
        public Guid Id { get; set; }

        public string ChannelName { get; set; }

        public string ChannelDescription { get; set; }
    }
}
