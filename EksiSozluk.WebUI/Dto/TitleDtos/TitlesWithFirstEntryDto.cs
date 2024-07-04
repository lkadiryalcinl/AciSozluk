using EksiSozluk.Application.Dtos.EntryDtos;

namespace EksiSozluk.WebUI.Dto.TitleDtos
{
    public class TitlesWithFirstEntryDto
    {
        public Guid Id { get; set; }
        public string TitleName { get; set; }
        public string ChannelName { get; set; }
        public EntryWithoutTitleInfoDto FirstEntry { get; set; }
        
    }
}
