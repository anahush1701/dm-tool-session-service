using SessionService.Models;

namespace SessionService.Interfaces
{
    public interface ICampaignRepository
    {
        public Task<IEnumerable<Campaign>> GetCampaignsAsync();
        public Task<Campaign> GetCampaignAsync(int id);
        public void AddCampaign(Campaign Campaign);
        public void DeleteCampaign(int id);
        public Task UpdateCampaign(Campaign Campaign);
        public Task SaveChangesAsync();
    }
}
