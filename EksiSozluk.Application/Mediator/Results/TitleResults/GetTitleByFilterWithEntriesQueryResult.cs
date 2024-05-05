using EksiSozluk.Application.Dtos.EntryDtos;
using EksiSozluk.Domain.Entities;

namespace EksiSozluk.Application.Mediator.Results.TitleResults
{
    public class GetTitleByFilterWithEntriesQueryResult
    {
        public Guid Id { get; set; }
        public string TitleName { get; set; }
        public List<EntryWithoutTitleInfoDto> EntryList { get; set; }

    }
}
