using Microsoft.EntityFrameworkCore;
using SessionService.Models.Joins;

namespace SessionService.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Session
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Campaign Campaign { get; set; }
        public List<PlayerSession> PlayerSessions { get; set; }
        public List<LocationSession> LocationSessions { get; set; }
        public List<OrganizationSession> OrganizationSessions { get; set; }
        public List<DmSession> DmSessions { get; set; }
        public List<Note> Notes { get; set; }
        public List<SessionNpc> SessionNpcs { get; set; }

        public int CampaignId { get; set; }
    }
}
