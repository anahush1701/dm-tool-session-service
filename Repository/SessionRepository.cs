using Microsoft.EntityFrameworkCore;
using SessionService.Context;
using SessionService.Interfaces;
using SessionService.Models;

namespace SessionService.Repository
{
    public class SessionRepository : ISessionRepository
    {
        private SessionServiceDbContext _context;

        public SessionRepository(SessionServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddSession(Session session)
        {
            _context.Sessions.Add(session); new NotImplementedException();
        }

        public void DeleteSession(int id)
        {
            _context.Sessions.Remove(new Session { Id = id });
        }

        public async Task<Session> GetSessionAsync(int id)
        {
            return await _context.Sessions
                .Include(s => s.Notes)
                .Include(s => s.OrganizationSessions)
                .Include(s => s.LocationSessions)
                .Include(s => s.SessionNpcs)
                .Include(s => s.DmSessions)
                .Include(s => s.PlayerSessions)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Session>> GetSessionsAsync()
        {
            return await _context.Sessions
                .Include(s => s.Notes)
                .Include(s => s.OrganizationSessions)
                .Include(s => s.SessionNpcs)
                .Include(s => s.LocationSessions)
                .Include(s => s.PlayerSessions)
                .Include(s => s.DmSessions)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateSession(Session session)
        {
            throw new NotImplementedException();
        }
    }
}
