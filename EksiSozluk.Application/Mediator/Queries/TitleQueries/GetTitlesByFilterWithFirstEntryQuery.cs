using EksiSozluk.Application.Mediator.Results.TitleResults;
using MediatR;

namespace EksiSozluk.Application.Mediator.Queries.TitleQueries
{
    public class GetTitlesByFilterWithFirstEntryQuery : IRequest<List<GetTitlesByFilterWithFirstEntryQueryResult>>
    {
        public string Id { get; set; }
    }
}
