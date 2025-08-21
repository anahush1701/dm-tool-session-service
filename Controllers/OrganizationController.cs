using Microsoft.AspNetCore.Mvc;
using SessionService.Interfaces;
using SessionService.Models;
using SessionService.Repository;

namespace SessionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationController : ControllerBase
    {
        private IOrganizationRepository _organizationRepository;
        public OrganizationController(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository ?? throw new ArgumentNullException(nameof(organizationRepository));
        }

        [HttpPost("create", Name = "createOrganization")]
        public async Task<ActionResult<Organization>> CreateAsync([FromBody] Organization organization)
        {
            if (organization == null)
            {
                return BadRequest("Organization cannot be null.");
            }

            _organizationRepository.AddOrganization(organization);
            await _organizationRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAsync), new { id = organization.Id }, organization);
        }

        [HttpGet("get", Name = "getAllOrganizations")]
        public async Task<IEnumerable<Organization>> GetAsync()
        {
            return await _organizationRepository.GetOrganizationsAsync();
        }

        [HttpDelete("{id}", Name = "deleteOrganization")]
        public async Task DeleteAsync(int id)
        {
            _organizationRepository.DeleteOrganization(id);
            await _organizationRepository.SaveChangesAsync();
        }

        [HttpGet("{id}", Name = "getOrganization")]
        public async Task<Organization> GetGetAsync(int id)
        {
            return await _organizationRepository.GetOrganizationAsync(id);
        }
    }
}
