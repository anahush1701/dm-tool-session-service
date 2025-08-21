using SessionService.Models;

namespace SessionService.Interfaces
{
    public interface ISessionRepository
    {
        public Task<IEnumerable<Session>> GetSessionsAsync();
        public Task<Session> GetSessionAsync(int id);
        public void AddSession(Session session);
        public void DeleteSession(int id);
        public void UpdateSession(Session session);
        public Task SaveChangesAsync();
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                