using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuckTracker.Models.Tables
{
    public class HeatPrediction
    {
        public int MamaDogId { get; set; }
        public DateTime Date { get; set; }
        public int HeatPredictionId { get; set; }
    }
}