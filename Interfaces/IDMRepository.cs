using SessionService.Models;

namespace SessionService.Interfaces
{
    public interface IDMRepository
    {
        public Task<IEnumerable<DungeonMaster>> GetDMsAsync();
        public Task<DungeonMaster> GetDMAsync(int id);
        public void AddDM(DungeonMaster DM);
        public void DeleteDM(int id);
        public void UpdateDM(DungeonMaster DM);
        public Task SaveChangesAsync();
    }
}
