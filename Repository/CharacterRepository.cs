using Microsoft.EntityFrameworkCore;
using SessionService.Context;
using SessionService.Interfaces;
using SessionService.Models;

namespace SessionService.Repository
{
    public class CharacterRepository : ICharacterRepository
    {
        private SessionServiceDbContext _context;

        public CharacterRepository(SessionServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddCharacter(Character Character)
        {
            _context.Characters.Add(Character); new NotImplementedException();
        }

        public void DeleteCharacter(int id)
        {
            _context.Characters.Remove(new Character { Id = id });
        }

        public async Task<Character> GetCharacterAsync(int id)
        {
            return await _context.Characters
                .Include(s => s.Player)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Character>> GetCharactersAsync()
        {
            return await _context.Characters
                .Include(s => s.Player)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateCharacter(Character Character)
        {
            throw new NotImplementedException();
        }
    }
}
