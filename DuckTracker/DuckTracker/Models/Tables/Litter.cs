using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuckTracker.Models.Tables
{
    public class Litter
    {
        public int LitterId { get; set; }
        public int MamaDogId { get; set; }
        public int PapaDogId { get; set; }
        public DateTime BirthDate { get; set; }
        public int PuppyCount { get; set; }
    }
}