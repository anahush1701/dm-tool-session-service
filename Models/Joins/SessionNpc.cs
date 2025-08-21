namespace SessionService.Models.Joins
{
    public class SessionNpc
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }

        public int NpcId { get; set; }
        public Npc Npc { get; set; }
    }
}