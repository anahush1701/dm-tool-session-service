namespace SessionService.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
