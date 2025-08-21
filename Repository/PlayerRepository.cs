using Microsoft.EntityFrameworkCore;
using SessionService.Context;
using SessionService.Interfaces;
using SessionService.Models;

namespace SessionService.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private SessionServiceDbContext _context;

        public PlayerRepository(SessionServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddPlayer(Player Player)
        {
            _context.Players.Add(Player); new NotImplementedException();
        }

        public void DeletePlayer(int id)
        {
            _context.Players.Remove(new Player { Id = id });
        }

        public async Task<Player> GetPlayerAsync(int id)
        {
            return await _context.Players
                .Include(s => s.CampaignPlayers)
                .Include(s => s.PlayerSessions)
                .Include(s => s.Characters)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Player>> GetPlayersAsync()
        {
            return await _context.Players
                .Include(s => s.CampaignPlayers)
                .Include(s => s.PlayerSessions)
                .Include(s => s.Characters)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdatePlayer(Player Player)
        {
            throw new NotImplementedException();
        }
    }
}
