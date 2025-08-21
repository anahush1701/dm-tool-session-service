using Microsoft.AspNetCore.Mvc;
using SessionService.Interfaces;
using SessionService.Models;

namespace SessionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampaignController : ControllerBase
    {
        private ICampaignRepository _campaignRepository;
        public CampaignController(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository ?? throw new ArgumentNullException(nameof(campaignRepository));
        }

        [HttpPost("create", Name = "createCampaign")]
        public async Task<ActionResult<Campaign>> CreateAsync([FromBody] Campaign Campaign)
        {
            if (Campaign == null)
            {
                return BadRequest("Campaign cannot be null.");
            }

            _campaignRepository.AddCampaign(Campaign);
            await _campaignRepository.SaveChangesAsync();

            return new ActionResult<Campaign>(Campaign);
        }

        [HttpPut("{id}", Name = "updateCampaign")]
        public async Task<ActionResult<Campaign>> UpdateAsync(int id, [FromBody] Campaign campaign)
        {
            if (campaign == null || campaign.Id != id)
            {
                return BadRequest("Campaign is null or ID mismatch.");
            }

            var existingCampaign = await _campaignRepository.GetCampaignAsync(id);
            if (existingCampaign == null)
            {
                return NotFound($"Campaign with ID {id} not found.");
            }

            _campaignRepository.UpdateCampaign(campaign);
            await _campaignRepository.SaveChangesAsync();

            return Ok(campaign);
        }

        [HttpGet("get", Name = "getAllCampaigns")]
        public async Task<IEnumerable<Campaign>> GetAsync()
        {
            return await _campaignRepository.GetCampaignsAsync();
        }

        [HttpDelete("{id}", Name = "deleteCampaign")]
        public async Task DeleteAsync(int id)
        {
            _campaignRepository.DeleteCampaign(id);
            await _campaignRepository.SaveChangesAsync();
        }

        [HttpGet("{id}", Name = "getCampaign")]
        public async Task<Campaign> GetAsync(int id)
        {
            return await _campaignRepository.GetCampaignAsync(id);
        }
    }
}
