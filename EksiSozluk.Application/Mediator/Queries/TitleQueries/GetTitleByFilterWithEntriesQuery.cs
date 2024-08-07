﻿using EksiSozluk.Application.Mediator.Results.TitleResults;
using MediatR;

namespace EksiSozluk.Application.Mediator.Queries.TitleQueries
{
    public class GetTitleByFilterWithEntriesQuery : IRequest<GetTitleByFilterWithEntriesQueryResult>
    {
        public string Id { get; set; }
        public string UserId { get; set; }

    }
}
