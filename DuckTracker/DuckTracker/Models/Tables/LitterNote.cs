using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuckTracker.Models.Tables
{
    public class LitterNote
    {
        public int LitterNoteId { get; set; }
        public int LitterId { get; set; }
        public string NoteTitle { get; set; }
        public string Note { get; set; }
        public DateTime DateCreated { get; set; }
    }
}