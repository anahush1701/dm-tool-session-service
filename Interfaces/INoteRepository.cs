using SessionService.Models;

namespace SessionService.Interfaces
{
    public interface INoteRepository
    {
        public Task<IEnumerable<Note>> GetNotesAsync();
        public Task<Note> GetNoteAsync(int id);
        public void AddNote(Note Note);
        public void DeleteNote(int id);
        public Task UpdateNote(Note Note);
        public Task SaveChangesAsync();
    }
}
