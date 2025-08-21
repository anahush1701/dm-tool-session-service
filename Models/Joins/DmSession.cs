namespace SessionService.Models.Joins
{
    public class DmSession
    {
        public int Id { get; set; }
        public int DungeonMasterId { get; set; }
        public DungeonMaster DungeonMaster { get; set; }

        public int SessionId { get; set; }
        public Session Session { get; set; }
    }
}