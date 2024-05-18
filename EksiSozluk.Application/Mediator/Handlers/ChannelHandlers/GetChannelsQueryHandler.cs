using EksiSozluk.Application.Interfaces;
using EksiSozluk.Application.Mediator.Queries.ChannelQueries;
using EksiSozluk.Application.Mediator.Results.ChannelResults;
using EksiSozluk.Domain.Entities;
using MediatR;

namespace EksiSozluk.Application.Mediator.Handlers.ChannelHandlers
{
    internal class GetChannelsQueryHandler : IRequestHandler<GetChannelsQuery, List<GetChannelsQueryResult>>
    {
        private readonly IRepository<Channel> _repository;

        public GetChannelsQueryHandler(IRepository<Channel> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetChannelsQueryResult>> Handle(GetChannelsQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            
            var results = values.Select(x => new GetChannelsQueryResult
            {
                Id = x.Id,
                ChannelDescription = x.ChannelDescription,
                ChannelName = x.ChannelName,
            }).ToList();
            return results;
        }
    }
}
