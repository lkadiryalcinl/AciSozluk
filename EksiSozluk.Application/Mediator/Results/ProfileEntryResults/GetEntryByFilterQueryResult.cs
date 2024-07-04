namespace EksiSozluk.Application.Mediator.Results.ProfileEntryResults
{
    public class GetEntryByFilterQueryResult
    {
        public Guid Id { get; set; }
        public Guid TitleId { get; set; }
        public string TitleName { get; set; }
        public string ChannelName { get; set; }
        public string EntryContent { get; set; }
    }
}
