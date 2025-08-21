namespace SessionService.Models.Joins
{
    public class LocationSession
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }

        public int SessionId { get; set; }
        public Session Session { get; set; }
    }
}