namespace SessionService.Models.Joins
{
    public class LocationOrganization
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}