using Microsoft.AspNetCore.Mvc;
using SessionService.Interfaces;
using SessionService.Models;

namespace SessionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DMController : ControllerBase
    {
        private IDMRepository _DMRepository;
        public DMController(IDMRepository DMRepository)
        {
            _DMRepository = DMRepository ?? throw new ArgumentNullException(nameof(DMRepository));
        }

        //[HttpPost("create", Name = "createDM")]
        //public async Task<ActionResult<DungeonMaster>> CreateAsync([FromBody] DungeonMaster DM)
        //{
        //    if (DM == null)
        //    {
        //        return BadRequest("DM cannot be null.");
        //    }

        //    _DMRepository.AddDM(DM);
        //    await _DMRepository.SaveChangesAsync();

        //    return new ActionResult<DungeonMaster>(DM);
        //}

        [HttpGet("get", Name = "getAllDMs")]
        public async Task<IEnumerable<DungeonMaster>> GetAsync()
        {
            return await _DMRepository.GetDMsAsync();
        }

        //[HttpDelete("{id}", Name = "deleteDM")]
        //public async Task DeleteAsync(int id)
        //{
        //    _DMRepository.DeleteDM(id);
        //    await _DMRepository.SaveChangesAsync();
        //}

        [HttpGet("{id}", Name = "getDM")]
        public async Task<DungeonMaster> GetAsync(int id)
        {
            return await _DMRepository.GetDMAsync(id);
        }
    }
}
