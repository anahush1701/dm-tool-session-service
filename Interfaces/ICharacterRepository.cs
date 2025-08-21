using SessionService.Models;

namespace SessionService.Interfaces
{
    public interface ICharacterRepository
    {
        public Task<IEnumerable<Character>> GetCharactersAsync();
        public Task<Character> GetCharacterAsync(int id);
        public void AddCharacter(Character Character);
        public void DeleteCharacter(int id);
        public void UpdateCharacter(Character Character);
        public Task SaveChangesAsync();
    }
}
