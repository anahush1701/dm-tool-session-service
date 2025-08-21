using Microsoft.EntityFrameworkCore;
using SessionService.Context;
using SessionService.Interfaces;
using SessionService.Models;

namespace SessionService.Repository
{
    public class NpcRepository : INpcRepository
    {
        private SessionServiceDbContext _context;

        public NpcRepository(SessionServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddNpc(Npc Npc)
        {
            _context.Npcs.Add(Npc); new NotImplementedException();
        }

        public void DeleteNpc(int id)
        {
            _context.Npcs.Remove(new Npc { Id = id });
        }

        public async Task<Npc> GetNpcAsync(int id)
        {
            return await _context.Npcs
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Npc>> GetNpcsAsync()
        {
            return await _context.Npcs.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateNpc(Npc Npc)
        {
            throw new NotImplementedException();
        }
    }
}
