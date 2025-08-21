using Microsoft.AspNetCore.Mvc;
using SessionService.Interfaces;
using SessionService.Models;

namespace SessionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private IPlayerRepository _playerRepository;
        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
        }

        //[HttpPost("create", Name = "createPlayer")]
        //public async Task<ActionResult<Player>> CreateAsync([FromBody] Player player)
        //{
        //    if (player == null)
        //    {
        //        return BadRequest("Players cannot be null.");
        //    }

        //    _playerRepository.AddPlayer(player);
        //    await _playerRepository.SaveChangesAsync();

        //    return new ActionResult<Player>(player);
        //}

        [HttpGet("get", Name = "getAllPlayers")]
        public async Task<IEnumerable<Player>> GetAsync()
        {
            return await _playerRepository.GetPlayersAsync();
        }

        //[HttpDelete("{id}", Name = "deletePlayer")]
        //public async Task DeleteAsync(int id)
        //{
        //    _playerRepository.DeletePlayer(id);
        //    await _playerRepository.SaveChangesAsync();
        //}

        [HttpGet("{id}", Name = "getPlayer")]
        public async Task<Player> GetAsync(int id)
        {
            return await _playerRepository.GetPlayerAsync(id);
        }
    }
}
