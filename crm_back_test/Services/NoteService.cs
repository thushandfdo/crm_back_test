using crm_back_test.Data;
using crm_back_test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace crm_back_test.Services
{
    public class NoteService : INoteService
    {
        private readonly DataContext _context;

        public NoteService(DataContext context) {
            _context = context;
        }

        public async Task<Note?> getNote(int noteId)
        {
            var note = await _context.Notes.FindAsync(noteId);

            return note;
        }

        public async Task<List<Note>?> getNotes()
        {
            var notes = await _context.Notes.ToListAsync();

            return notes;
        }

        public async Task<List<Note>?> postNote(Note newNote)
        {
            var note = await _context.Notes.Where(note => note.Title.Equals(newNote.Title)).ToListAsync();

            if(!note.IsNullOrEmpty())
            {
                return null;
            }

            _context.Notes.Add(newNote);
            await _context.SaveChangesAsync();

            return await _context.Notes.ToListAsync();
        }

        public async Task<List<Note>?> putNote(Note newNote)
        {
            var note = await _context.Notes.FindAsync(newNote.Id);

            if (note == null)
            {
                return null;
            }

            note.Title = newNote.Title;
            note.Details = newNote.Details;
            note.Category = newNote.Category;

            await _context.SaveChangesAsync();

            return await _context.Notes.ToListAsync();
        }

        public async Task<List<Note>?> deleteNote(int noteId)
        {
            var note = await _context.Notes.FindAsync(noteId);

            if (note == null)
            {
                return null;
            }

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();

            return await _context.Notes.ToListAsync();
        }
    }
}
