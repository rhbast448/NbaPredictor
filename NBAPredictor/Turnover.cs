using System;
using System.Collections.Generic;
using System.Text;

namespace NBAPredictor
{
    public class Turnover
    {
        public DateTime ImportDate { get; set; }
        public string Team { get; set; }
        public decimal PercentByYear { get; set; }
        public decimal PercentByYearHome { get; set; }
        public decimal PercentByYearAway { get; set; }

    }
}
