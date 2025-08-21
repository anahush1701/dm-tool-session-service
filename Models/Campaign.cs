using SessionService.Models.Joins;

namespace SessionService.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CampaignDungeonMaster> CampaignDungeonMasters { get; set; }
        public List<CampaignPlayer> CampaignPlayers { get; set; }
        public List<Character> Characters { get; set; }
        public List<Location> Locations { get; set; }
        public List<Organization> Organizations { get; set; }
        public List<Npc> Npcs { get; set; }
        public List<Session> Sessions { get; set; }
        public List<Note> Notes { get; set; }
    }
}
