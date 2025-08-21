using Microsoft.EntityFrameworkCore;
using SessionService.Models.Joins;

namespace SessionService.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Npc
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }

        public List<NpcOrganization> NpcOrganizations { get; set; }
        public List<SessionNpc> SessionNpcs { get; set; }
    }
}
