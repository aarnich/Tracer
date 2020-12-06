using System;
using System.Collections.Generic;
using System.Text;

namespace Tracer.Models { 

    public enum NotesItemType
    {
        Activity,
        Todo
    }
    public class NotesItem
    {
        public int Counter { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public NotesItemType Type { get; set; }
        public string Location { get; set; }
        public string Icon { get; set; }
        public string UserID { get; set; }
    }
    

}

