using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tracer.Models;

namespace Tracer.Services
{
    class NotesService
    {
        private static NotesService _instance;
        private FirebaseService _service = new FirebaseService();
        public static NotesService Instance
        {
            get
            {
                if (_instance == null) _instance = new NotesService();
                return _instance;
            }
        }
        public Task<List<NotesItem>> GetActualNotes()
        {
            return _service.GetAllCurrentUserNotes();
        }
    }
}
