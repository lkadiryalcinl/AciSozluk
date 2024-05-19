using EksiSozluk.Domain.Entities;
using MediatR;

namespace EksiSozluk.Application.Mediator.Commands.FollowChannelCommands
{
    public class CreateFollowChannelCommand : IRequest
    {
        public string UserId { get; set; }
        public Guid ChannelId { get; set; }
        public DateTime FollowDate { get; set; }
    }
}
