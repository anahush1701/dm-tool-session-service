using Microsoft.EntityFrameworkCore;
using SessionService.Context;
using SessionService.Interfaces;
using SessionService.Models;

namespace SessionService.Repository
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private SessionServiceDbContext _context;

        public OrganizationRepository(SessionServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddOrganization(Organization Organization)
        {
            _context.Organizations.Add(Organization); new NotImplementedException();
        }

        public void DeleteOrganization(int id)
        {
            _context.Organizations.Remove(new Organization { Id = id });
        }

        public async Task<Organization> GetOrganizationAsync(int id)
        {
            return await _context.Organizations
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Organization>> GetOrganizationsAsync()
        {
            return await _context.Organizations.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateOrganization(Organization Organization)
        {
            throw new NotImplementedException();
        }
    }
}
