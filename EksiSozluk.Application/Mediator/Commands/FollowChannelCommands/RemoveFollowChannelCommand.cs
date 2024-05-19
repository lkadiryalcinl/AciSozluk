using MediatR;

namespace EksiSozluk.Application.Mediator.Commands.FollowChannelCommands
{
    public class RemoveFollowChannelCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
