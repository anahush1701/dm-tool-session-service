namespace SessionService.Models
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int? SessionId { get; set; }
        public int? CampaignId { get; set; }
        public Guid UserId { get; set; }
        public bool IsPublic { get; set; }
    }
}
