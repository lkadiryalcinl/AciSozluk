namespace EksiSozluk.WebUI.Dto.EntryDtos
{
    public class CreateEntryDto
    {
        public string ChannelName { get; set; }
        public string EntryContent { get; set; }
        public string UserId { get; set; }
        public Guid TitleId { get; set; }
    }
}
