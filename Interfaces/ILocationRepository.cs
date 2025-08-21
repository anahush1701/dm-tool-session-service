using SessionService.Models;

namespace SessionService.Interfaces
{
    public interface ILocationRepository
    {
        public Task<IEnumerable<Location>> GetLocationsAsync();
        public Task<Location> GetLocationAsync(int id);
        public void AddLocation(Location Location);
        public void DeleteLocation(int id);
        public void UpdateLocation(Location Location);
        public Task SaveChangesAsync();
    }
}
