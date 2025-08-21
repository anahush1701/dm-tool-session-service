namespace SessionService.Models.Joins
{
    public class PlayerSession
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int SessionId { get; set; }
        public Session Session { get; set; }
    }
}