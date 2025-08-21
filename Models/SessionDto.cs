namespace SessionService.Models
{
    public class SessionDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CampaignId { get; set; }
        public List<int> OrganizationIds { get; set; }
        public List<int> NPCIds { get; set; }
        public List<int> LocationIds { get; set; }
        public List<int> PlayerIds { get; set; }
        public List<int> DmIds { get; set; }
        public List<int> NoteIds { get; set; }
    }
}
