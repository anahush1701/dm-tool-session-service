namespace SessionService.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Session? Session { get; set; }
        public Campaign? Campaign { get; set; }
        public int? SessionId { get; set; }
        public int? CampaignId { get; set; }
        public Guid UserId { get; set; }
        public bool IsPublic { get; set; }
    }
}
