using EksiSozluk.Application.Interfaces;
using EksiSozluk.Application.Mediator.Commands.FollowChannelCommands;
using EksiSozluk.Domain.Entities;
using MediatR;

namespace EksiSozluk.Application.Mediator.Handlers.FollowChannelHandlers
{
    internal class CreateFollowChannelCommandHandler : IRequestHandler<CreateFollowChannelCommand>
    {
        private readonly IRepository<FollowChannel> _repository;

        public CreateFollowChannelCommandHandler(IRepository<FollowChannel> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFollowChannelCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new FollowChannel
            {
                ChannelId = request.ChannelId,
                UserId = request.UserId
            });
        }
    }
}
