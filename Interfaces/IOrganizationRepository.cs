using SessionService.Models;

namespace SessionService.Interfaces
{
    public interface IOrganizationRepository
    {
        public Task<IEnumerable<Organization>> GetOrganizationsAsync();
        public Task<Organization> GetOrganizationAsync(int id);
        public void AddOrganization(Organization Organization);
        public void DeleteOrganization(int id);
        public void UpdateOrganization(Organization Organization);
        public Task SaveChangesAsync();
    }
}
