using MediatR;

namespace EksiSozluk.Application.Mediator.Commands.FollowChannelCommands
{
    public class RemoveFollowChannelCommand : IRequest
    {
        public Guid ChannelId { get; set; }
        public string UserId { get; set; }
    }
}
