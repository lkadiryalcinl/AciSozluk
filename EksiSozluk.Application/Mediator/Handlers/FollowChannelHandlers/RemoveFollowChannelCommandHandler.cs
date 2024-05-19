using EksiSozluk.Application.Interfaces;
using EksiSozluk.Application.Mediator.Commands.FollowChannelCommands;
using EksiSozluk.Domain.Entities;
using MediatR;

namespace EksiSozluk.Application.Mediator.Handlers.FollowChannelHandlers
{
    internal class RemoveFollowChannelCommandHandler : IRequestHandler<RemoveFollowChannelCommand>
    {
        private readonly IRepository<FollowChannel> _repository;

        public RemoveFollowChannelCommandHandler(IRepository<FollowChannel> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFollowChannelCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
