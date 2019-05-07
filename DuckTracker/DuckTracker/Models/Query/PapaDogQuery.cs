using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuckTracker.Models.Query
{
    public class PapaDogQuery
    {
        public int PapaDogId { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public int PuppyCount { get; set; }
        public int LitterCount { get; set; }
    }
}