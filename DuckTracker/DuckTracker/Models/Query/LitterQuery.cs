using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuckTracker.Models.Query
{
    public class LitterQuery
    {
        public int LitterId { get; set; }
        public int MamaDogId { get; set; }
        public string MamaDogName { get; set; }
        public int PapaDogId { get; set; }
        public string PapaDogName { get; set; }
        public DateTime BirthDate { get; set; }
        public int PuppyCount { get; set; }
    }
}