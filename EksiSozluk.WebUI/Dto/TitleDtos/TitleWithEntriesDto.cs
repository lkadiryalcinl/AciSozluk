using EksiSozluk.Application.Dtos.EntryDtos;

namespace EksiSozluk.WebUI.Dto.TitleDtos
{
    public class TitleWithEntriesDto
    {
        public Guid Id { get; set; }
        public string TitleName { get; set; }
        public string ChannelName { get; set; }
        public List<EntryWithoutTitleInfoDto> EntryList { get; set; }
    }
}
