using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuckTracker.Models.Query
{
    public class UpComingInHeatQuery
    {
        public int MamaDogId { get; set; }
        public string MamaName { get; set; }
        public DateTime Date { get; set; }
    }
}