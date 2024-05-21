namespace EksiSozluk.WebUI.Dto.ProfileDtos
{
    public class UpdateEntryDto
    {
        public Guid Id { get; set; }
        public string EntryContent { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsEntryUpdated { get; set; } = false;
    }
}
