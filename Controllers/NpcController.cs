using Microsoft.AspNetCore.Mvc;
using SessionService.Interfaces;
using SessionService.Models;
using SessionService.Repository;

namespace SessionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NpcController : ControllerBase
    {
        private INpcRepository _npcRepository;
        public NpcController(INpcRepository npcRepository)
        {
            _npcRepository = npcRepository ?? throw new ArgumentNullException(nameof(npcRepository));
        }

        [HttpPost("create", Name = "createNpc")]
        public async Task<ActionResult<Npc>> CreateAsync([FromBody] Npc npc)
        {
            if (npc == null)
            {
                return BadRequest("Npc cannot be null.");
            }

            _npcRepository.AddNpc(npc);
            await _npcRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAsync), new { id = npc.Id }, npc);
        }

        [HttpGet("get", Name = "getAllNpcs")]
        public async Task<IEnumerable<Npc>> GetAsync()
        {
            return await _npcRepository.GetNpcsAsync();
        }

        [HttpDelete("{id}", Name = "deleteNpc")]
        public async Task DeleteAsync(int id)
        {
            _npcRepository.DeleteNpc(id);
            await _npcRepository.SaveChangesAsync();
        }

        [HttpGet("{id}", Name = "getNpc")]
        public async Task<Npc> GetAsync(int id)
        {
            return await _npcRepository.GetNpcAsync(id);
        }
    }
}
