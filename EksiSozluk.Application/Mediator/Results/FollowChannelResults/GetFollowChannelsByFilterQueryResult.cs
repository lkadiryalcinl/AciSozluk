using EksiSozluk.Domain.Entities;

namespace EksiSozluk.Application.Mediator.Results.FollowChannelResults
{
    public class GetFollowChannelsByFilterQueryResult
    {
        public Guid Id { get; set; }
        public Guid ChannelId { get; set; }
        public DateTime FollowedDate { get; set; }
    }
}
