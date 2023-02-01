using crm_back_test.Models;
using Microsoft.AspNetCore.Mvc;

namespace crm_back_test.Services
{
    public interface INoteService
    {
        public Task<Note?> getNote(int noteId);
        public Task<List<Note>?> getNotes();
        public Task<List<Note>?> postNote(Note newNote);
        public Task<List<Note>?> putNote(Note newNote);
        public Task<List<Note>?> deleteNote(int noteId);
    }
}
