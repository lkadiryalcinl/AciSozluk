namespace EksiSozluk.WebUI.Dto.ProfileDtos
{
    public class TitleWithEntrySingleDto
    {
        public Guid Id { get; set; }
        public Guid TitleId { get; set; }
        public string TitleName { get; set; }
        public string ChannelName { get; set; }
        public string EntryContent { get; set; }
    }
}
