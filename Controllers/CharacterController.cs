using Microsoft.AspNetCore.Mvc;
using SessionService.Interfaces;
using SessionService.Models;

namespace SessionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private ICharacterRepository _CharacterRepository;
        public CharacterController(ICharacterRepository CharacterRepository)
        {
            _CharacterRepository = CharacterRepository ?? throw new ArgumentNullException(nameof(CharacterRepository));
        }

        [HttpPost("create", Name = "createCharacter")]
        public async Task<ActionResult<Character>> CreateAsync([FromBody] Character Character)
        {
            if (Character == null)
            {
                return BadRequest("Character cannot be null.");
            }

            _CharacterRepository.AddCharacter(Character);
            await _CharacterRepository.SaveChangesAsync();

            return new ActionResult<Character>(Character);
        }

        [HttpGet("get", Name = "getAllCharacters")]
        public async Task<IEnumerable<Character>> GetAsync()
        {
            return await _CharacterRepository.GetCharactersAsync();
        }

        [HttpDelete("{id}", Name = "deleteCharacter")]
        public async Task DeleteAsync(int id)
        {
            _CharacterRepository.DeleteCharacter(id);
            await _CharacterRepository.SaveChangesAsync();
        }

        [HttpGet("{id}", Name = "getCharacter")]
        public async Task<Character> GetAsync(int id)
        {
            return await _CharacterRepository.GetCharacterAsync(id);
        }
    }
}
