using Microsoft.EntityFrameworkCore;
using SessionService.Context;
using SessionService.Interfaces;
using SessionService.Models;

namespace SessionService.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private SessionServiceDbContext _context;

        public LocationRepository(SessionServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddLocation(Location Location)
        {
            _context.Locations.Add(Location); new NotImplementedException();
        }

        public void DeleteLocation(int id)
        {
            _context.Locations.Remove(new Location { Id = id });
        }

        public async Task<Location> GetLocationAsync(int id)
        {
            return await _context.Locations
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateLocation(Location Location)
        {
            throw new NotImplementedException();
        }
    }
}
