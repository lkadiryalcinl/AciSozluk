using EksiSozluk.Domain.Entities;
using MediatR;

namespace EksiSozluk.Application.Mediator.Commands.FollowChannelCommands
{
    public class CreateFollowChannelCommand : IRequest
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public Guid ChannelId { get; set; }
        public Channel Channel { get; set; }
    }
}
