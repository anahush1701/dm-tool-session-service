using Microsoft.AspNetCore.Mvc;
using SessionService.Interfaces;
using SessionService.Models;
using SessionService.Repository;

namespace SessionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private ILocationRepository _locationRepository;
        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository ?? throw new ArgumentNullException(nameof(locationRepository));
        }

        [HttpPost("create", Name = "createLocation")]
        public async Task<ActionResult<Location>> CreateAsync([FromBody] Location location)
        {
            if (location == null)
            {
                return BadRequest("Location cannot be null.");
            }

            _locationRepository.AddLocation(location);
            await _locationRepository.SaveChangesAsync();

            return new ActionResult<Location>(location);
        }

        [HttpGet("get", Name = "getAllLocations")]
        public async Task<IEnumerable<Location>> GetAsync()
        {
            return await _locationRepository.GetLocationsAsync();
        }

        [HttpDelete("{id}", Name = "deleteLocation")]
        public async Task DeleteAsync(int id)
        {
            _locationRepository.DeleteLocation(id);
            await _locationRepository.SaveChangesAsync();
        }

        [HttpGet("{id}", Name = "getLocation")]
        public async Task<Location> GetAsync(int id)
        {
            return await _locationRepository.GetLocationAsync(id);
        }
    }
}
