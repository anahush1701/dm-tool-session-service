using Microsoft.AspNetCore.Mvc;
using SessionService.Interfaces;
using SessionService.Models;

namespace SessionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private INoteRepository _noteRepository;
        public NoteController(INoteRepository NoteRepository)
        {
            _noteRepository = NoteRepository ?? throw new ArgumentNullException(nameof(NoteRepository));
        }

        [HttpPost("create", Name = "createNote")]
        public async Task<ActionResult<Note>> CreateAsync([FromBody] NoteDto noteDto)
        {
            if (noteDto == null)
            {
                return BadRequest("note cannot be null.");
            }

            var note = new Note
            {
                Title = noteDto.Title,
                Content = noteDto.Content,
                CampaignId = noteDto.CampaignId,
                SessionId = noteDto.SessionId,
                UserId = noteDto.UserId,
                IsPublic = noteDto.IsPublic,
            };

            _noteRepository.AddNote(note);
            await _noteRepository.SaveChangesAsync();

            return new ActionResult<Note>(note);
        }

        [HttpPut("{id}", Name = "updateNote")]
        public async Task<ActionResult<Note>> UpdateAsync(int id, [FromBody] Note Note)
        {
            if (Note == null || Note.Id != id)
            {
                return BadRequest("noteDto is null or ID mismatch.");
            }

            var existingNote = await _noteRepository.GetNoteAsync(id);
            if (existingNote == null)
            {
                return NotFound($"noteDto with ID {id} not found.");
            }

            _noteRepository.UpdateNote(Note);
            await _noteRepository.SaveChangesAsync();

            return Ok(Note);
        }

        [HttpGet("get", Name = "getAllNotes")]
        public async Task<IEnumerable<Note>> GetAsync()
        {
            return await _noteRepository.GetNotesAsync();
        }

        [HttpDelete("{id}", Name = "deleteNote")]
        public async Task DeleteAsync(int id)
        {
            _noteRepository.DeleteNote(id);
            await _noteRepository.SaveChangesAsync();
        }

        [HttpGet("{id}", Name = "getNote")]
        public async Task<Note> GetAsync(int id)
        {
            return await _noteRepository.GetNoteAsync(id);
        }
    }
}
