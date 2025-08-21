using Microsoft.EntityFrameworkCore;
using SessionService.Context;
using SessionService.Interfaces;
using SessionService.Models;

namespace SessionService.Repository
{
    public class DMRepository : IDMRepository
    {
        private SessionServiceDbContext _context;

        public DMRepository(SessionServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddDM(DungeonMaster DM)
        {
            _context.DMs.Add(DM); new NotImplementedException();
        }

        public void DeleteDM(int id)
        {
            _context.DMs.Remove(new DungeonMaster { Id = id });
        }

        public async Task<DungeonMaster> GetDMAsync(int id)
        {
            return await _context.DMs
                .Include(s => s.CampaignDungeonMasters)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<DungeonMaster>> GetDMsAsync()
        {
            return await _context.DMs
                .Include(s => s.CampaignDungeonMasters)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateDM(DungeonMaster DM)
        {
            throw new NotImplementedException();
        }
    }
}
