using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuckTracker.Models.Tables
{
    public class MamaDogNote
    {
        public int MamaDogNoteId { get; set; }
        public int MamaDogId { get; set; }
        public string NoteTitle { get; set; }
        public string Note { get; set; }
        public DateTime DateCreated { get; set; }
    }
}