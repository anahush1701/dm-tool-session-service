namespace SessionService.Models.Joins
{
    public class CampaignPlayer
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}