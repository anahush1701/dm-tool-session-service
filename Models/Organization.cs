using Microsoft.EntityFrameworkCore;
using SessionService.Models.Joins;

namespace SessionService.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<LocationOrganization> LocationOrganizations { get; set; }
        public List<NpcOrganization> NpcOrganizations { get; set; }
        public List<OrganizationSession> OrganizationSessions { get; set; }

    }
}
