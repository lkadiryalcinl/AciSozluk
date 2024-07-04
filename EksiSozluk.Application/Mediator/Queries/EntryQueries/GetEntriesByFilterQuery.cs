﻿using EksiSozluk.Application.Mediator.Results.ProfileEntryResults;
using MediatR;

namespace EksiSozluk.Application.Mediator.Queries.EntryQueries
{
    public class GetEntriesByFilterQuery:IRequest<List<GetEntriesByFilterQueryResult>>
    {
        public string Id { get; set; }
    }
}
