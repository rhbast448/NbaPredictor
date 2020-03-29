using System;
using System.Collections.Generic;
using System.Text;

namespace NBAPredictor
{
    internal class StatsProcessor : IStatsProcessor
    {
        public List<Turnover> ProcessRawTurnovers(List<string> rawTurnovers)
        {
            var turnovers = new List<Turnover>();

            for (int i = 0; i < rawTurnovers.Count; i += 8)
            {
                decimal.TryParse(rawTurnovers[2 + i], out decimal perByYear);
                decimal.TryParse(rawTurnovers[5 + i], out decimal perByYearHome);
                decimal.TryParse(rawTurnovers[6 + i], out decimal perByYearAway);
                var turnoverToAdd = new Turnover
                {
                    ImportDate = DateTime.Now,
                    Team = rawTurnovers[1 + i],
                    PercentByYear = perByYear,
                    PercentByYearHome = perByYearHome,
                    PercentByYearAway = perByYearAway
                };
                turnovers.Add(turnoverToAdd);
            }
            return turnovers;
        }
    }
}
