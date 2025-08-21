using Microsoft.EntityFrameworkCore;
using SessionService.Context;
using SessionService.Interfaces;
using SessionService.Models;

namespace SessionService.Repository
{
    public class CampaignRepository : ICampaignRepository
    {
        private SessionServiceDbContext _context;

        public CampaignRepository(SessionServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddCampaign(Campaign Campaign)
        {
            _context.Campaigns.Add(Campaign);
        }

        public void DeleteCampaign(int id)
        {
            _context.Campaigns.Remove(new Campaign { Id = id });
        }

        public async Task<Campaign> GetCampaignAsync(int id)
        {
            return await _context.Campaigns
                .Include(s => s.CampaignDungeonMasters)
                .Include(s => s.Sessions)
                .Include(s => s.CampaignPlayers)
                .Include(s => s.Locations)
                .Include(s => s.Characters)
                .Include(s => s.Organizations)
                .Include(s => s.Npcs)
                .Include(s => s.Notes)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Campaign>> GetCampaignsAsync()
        {
            return await _context.Campaigns
                .Include(s => s.CampaignDungeonMasters)
                .Include(s => s.Sessions)
                .Include(s => s.CampaignPlayers)
                .Include(s => s.Locations)
                .Include(s => s.Characters)
                .Include(s => s.Organizations)
                .Include(s => s.Npcs)
                .Include(s => s.Notes)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCampaign(Campaign updatedCampaign)
        {
            // 1. Fetch the existing entity with all its related collections
            var existingCampaign = await _context.Campaigns
                .Include(c => c.CampaignDungeonMasters)
                .Include(c => c.CampaignPlayers)
                .Include(c => c.Characters)
                .Include(c => c.Sessions)
                .Include(c => c.Npcs)
                .Include(c => c.Locations)
                .Include(c => c.Organizations)
                .Include(c => c.Notes)
                .FirstOrDefaultAsync(c => c.Id == updatedCampaign.Id);

            if (existingCampaign == null)
            {
                // Handle the case where the campaign doesn't exist (e.g., throw an exception)
                throw new KeyNotFoundException($"Campaign with Id {updatedCampaign.Id} not found.");
            }

            // 2. Update scalar properties
            // This copies the primitive property values from the updatedCampaign to the existingCampaign
            _context.Entry(existingCampaign).CurrentValues.SetValues(updatedCampaign);

            // 3. Update navigation properties (collections)
            UpdateCollection(existingCampaign.CampaignDungeonMasters, updatedCampaign.CampaignDungeonMasters);
            UpdateCollection(existingCampaign.CampaignPlayers, updatedCampaign.CampaignPlayers);
            UpdateCollection(existingCampaign.Characters, updatedCampaign.Characters);
            UpdateCollection(existingCampaign.Sessions, updatedCampaign.Sessions);
            UpdateCollection(existingCampaign.Npcs, updatedCampaign.Npcs);
            UpdateCollection(existingCampaign.Locations, updatedCampaign.Locations);
            UpdateCollection(existingCampaign.Organizations, updatedCampaign.Organizations);

            // 4. Save changes
            await _context.SaveChangesAsync();
        }

        private void UpdateCollection<T>(ICollection<T> existingCollection, ICollection<T> updatedCollection) where T : class
        {
            if (updatedCollection == null)
            {
                // If the new collection is null, clear the existing one.
                existingCollection.Clear();
                return;
            }

            var updatedIds = updatedCollection.Select(e => _context.Entry(e).Property("Id").CurrentValue).ToList();
            var existingItemsToRemove = existingCollection.Where(e => !updatedIds.Contains(_context.Entry(e).Property("Id").CurrentValue)).ToList();

            // Remove items that are no longer in the updated collection
            foreach (var itemToRemove in existingItemsToRemove)
            {
                existingCollection.Remove(itemToRemove);
            }

            // Add new items from the updated collection
            foreach (var newItem in updatedCollection)
            {
                var id = _context.Entry(newItem).Property("Id").CurrentValue;
                if (!existingCollection.Any(e => _context.Entry(e).Property("Id").CurrentValue.Equals(id)))
                {
                    // Attach the new item if it's not already tracked
                    if (_context.Entry(newItem).State == EntityState.Detached)
                    {
                        _context.Attach(newItem);
                    }
                    existingCollection.Add(newItem);
                }
            }
        }
    }
}
