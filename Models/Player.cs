using SessionService.Models.Joins;

namespace SessionService.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CampaignPlayer> CampaignPlayers { get; set; }
        public List<PlayerSession> PlayerSessions { get; set; }
        public List<Character> Characters { get; set; }
        public Guid UserId { get; set; }
    }
}
