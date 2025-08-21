namespace SessionService.Models.Joins
{
    public class NpcOrganization
    {
        public int Id { get; set; }
        public int NpcId { get; set; }
        public Npc Npc { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}