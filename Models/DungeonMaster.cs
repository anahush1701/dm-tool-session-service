using SessionService.Models.Joins;

namespace SessionService.Models
{
    public class DungeonMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CampaignDungeonMaster> CampaignDungeonMasters { get; set; }
        public List<DmSession> DmSessions { get; set; }
        public Guid UserId { get; set; }
    }
}
