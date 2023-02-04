using crm_back_test.Data;
using crm_back_test.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using crm_back_test.Services.NoteServices;

namespace crm_back_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("{noteId}")]
        public async Task<ActionResult<Note?>> getNote(int noteId)
        {
            var note = await _noteService.getNote(noteId);

            if (note == null)
            {
                return NotFound("Note does not exist");
            }

            return Ok(note);
        }

        [HttpGet]
        public async Task<ActionResult<List<Note>?>> getNotes()
        {
            var notes = await _noteService.getNotes();

            if (notes == null)
            {
                return NotFound("Notes list is Empty..!");
            }

            return Ok(notes);
        }

        [HttpPost]
        public async Task<ActionResult<List<Note>?>> postNote(Note newNote)
        {
            var notes = await _noteService.postNote(newNote);

            if (notes == null)
            {
                return NotFound("Note is already exist..!");
            }

            return Ok(notes);
        }

        [HttpPut]
        public async Task<ActionResult<List<Note>?>> putNote(Note newNote)
        {
            var notes = await _noteService.putNote(newNote);

            if (notes == null)
            {
                return NotFound("Note is not found..!");
            }

            return Ok(notes);
        }

        [HttpDelete("{noteId}")]
        public async Task<ActionResult<List<Note>?>> deleteNote(int noteId)
        {
            var notes = await _noteService.deleteNote(noteId);

            if (notes == null)
            {
                return NotFound("Note is not found..!");
            }

            return Ok(notes);
        }
    }
}
