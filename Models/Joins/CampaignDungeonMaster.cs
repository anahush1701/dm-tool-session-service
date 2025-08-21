namespace SessionService.Models.Joins
{
    public class CampaignDungeonMaster
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }

        public int DungeonMasterId { get; set; }
        public DungeonMaster DungeonMaster { get; set; }
    }
}