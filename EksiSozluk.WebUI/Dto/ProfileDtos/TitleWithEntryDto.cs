namespace EksiSozluk.WebUI.Dto.ProfileDtos
{
    public class TitleWithEntryDto
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string TitleName { get; set; }
        public string EntryContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserName { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
