using SessionService.Models;

namespace SessionService.Interfaces
{
    public interface INpcRepository
    {
        public Task<IEnumerable<Npc>> GetNpcsAsync();
        public Task<Npc> GetNpcAsync(int id);
        public void AddNpc(Npc Npc);
        public void DeleteNpc(int id);
        public void UpdateNpc(Npc Npc);
        public Task SaveChangesAsync();
    }
}
