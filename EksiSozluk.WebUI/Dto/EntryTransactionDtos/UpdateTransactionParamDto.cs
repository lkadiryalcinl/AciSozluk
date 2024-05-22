namespace EksiSozluk.WebUI.Dto.EntryTransactionDtos
{
    public class UpdateTransactionParamDto
    {
        public string UserId { get; set; }
        public string EntryId { get; set; }
        public string ActionType { get; set; }
        public string ChannelName { get; set; }
        public string TitleId { get; set; }
    }
}
