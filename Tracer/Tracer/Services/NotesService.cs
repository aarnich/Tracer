using System;
using System.Collections.Generic;
using System.Text;
using Tracer.Models;

namespace Tracer.Services
{
    class NotesService
    {
        private static NotesService _instance;
        public static NotesService Instance
        {
            get
            {
                if (_instance == null) _instance = new NotesService();
                return _instance;
            }
        }
        public List<NotesItem> GetActualNotes()
        {
            return new List<NotesItem>
            {
                new NotesItem{ Type = NotesItemType.Activity, Content="Learn all about Xamarin Forms", Date =DateTime.Today.ToString(), Location="Coffee Project, Makati City, Philippines", Icon="notif.png",Time=DateTime.Now.ToString("hh:mm tt")},
                new NotesItem{ Type = NotesItemType.Activity, Content="Study C#", Date =DateTime.Today.ToString(), Location="Starbucks, Taft Ave., Pasay City, Philippines",Icon="notif.png",Time=DateTime.Now.ToString("hh:mm tt")},
                new NotesItem{ Type = NotesItemType.Activity, Content="Learn all about Xamarin Forms", Date =DateTime.Today.ToString(),Location="Starbucks, Taft Ave., Pasay City, Philippines",Icon="notif.png",Time=DateTime.Now.ToString("hh:mm tt")},
               new NotesItem{ Type = NotesItemType.Activity, Content="Learn all about Xamarin Forms", Date =DateTime.Today.ToString(),Location="Starbucks, Taft Ave., Pasay City, Philippines",Icon="notif.png",Time=DateTime.Now.ToString("hh:mm tt")}

            };
        }
    }
}
