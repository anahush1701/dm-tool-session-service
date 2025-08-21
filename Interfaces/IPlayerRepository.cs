using SessionService.Models;

namespace SessionService.Interfaces
{
    public interface IPlayerRepository
    {
        public Task<IEnumerable<Player>> GetPlayersAsync();
        public Task<Player> GetPlayerAsync(int id);
        public void AddPlayer(Player Player);
        public void DeletePlayer(int id);
        public void UpdatePlayer(Player Player);
        public Task SaveChangesAsync();
    }
}
