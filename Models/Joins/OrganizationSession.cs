namespace SessionService.Models.Joins
{
    public class OrganizationSession
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public int SessionId { get; set; }
        public Session Session { get; set; }
    }
}