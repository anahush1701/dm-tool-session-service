using Microsoft.EntityFrameworkCore;
using SessionService.Context;
using SessionService.Interfaces;
using SessionService.Models;

namespace SessionService.Repository
{
    public class NoteRepository : INoteRepository
    {
        private SessionServiceDbContext _context;

        public NoteRepository(SessionServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddNote(Note Note)
        {
            _context.Notes.Add(Note);
        }

        public void DeleteNote(int id)
        {
            _context.Notes.Remove(new Note { Id = id });
        }

        public async Task<Note> GetNoteAsync(int id)
        {
            return await _context.Notes
                .Include(s => s.Campaign)
                .Include(s => s.Session)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Note>> GetNotesAsync()
        {
            return await _context.Notes
                .Include(s => s.Campaign)
                .Include(s => s.Session)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNote(Note Note)
        {
            throw new NotImplementedException();
        }
    }
}
