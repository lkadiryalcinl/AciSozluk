using EksiSozluk.Application.Mediator.Results.TitleResults;
using MediatR;

namespace EksiSozluk.Application.Mediator.Queries.TitleQueries
{
    public class GetTitleByFilterQuery : IRequest<List<GetTitleByFilterQueryResult>>
    {
        public string ChannelName { get; set; }
    }
}