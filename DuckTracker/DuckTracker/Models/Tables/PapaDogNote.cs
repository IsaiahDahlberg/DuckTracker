using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuckTracker.Models.Tables
{
    public class PapaDogNote
    {
        public int PapaDogNoteId { get; set; }
        public int PapaDogId { get; set; }
        public string NoteTitle { get; set; }
        public string Note { get; set; }
        public DateTime DateCreated { get; set; }
    }
}