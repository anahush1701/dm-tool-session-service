using Microsoft.EntityFrameworkCore;
using SessionService.Models.Joins;

namespace SessionService.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<LocationOrganization> LocationOrganizations { get; set; }
        public List<LocationSession> LocationSessions { get; set; }
    }
}
