using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAPredictor
{
    public class StatsProcessor: IStatsProcessor
    {
        private readonly IStatsProvider[] _providers;

        public StatsProcessor(IStatsProvider[] providers)
        {
            this._providers = providers;            
        }

        public async Task<TeamStats[]> GetDailyStatsAsync()
        {            
            var allStats = new Dictionary<string, TeamStats>();
            foreach (var provider in _providers)
            {
                var providerStats = await provider.GetStatsAsync();
                foreach (var stat in providerStats)
                {
                    
                    if (!allStats.TryGetValue(stat["Team"].ToString(), out var teamStat))
                    {
                        teamStat = new TeamStats { Name = stat["Team"].ToString() };
                        allStats.Add(stat["Team"].ToString(), teamStat);
                    }
                    foreach (var item in stat)
                    {
                        switch (item.Key)
                        {
                            case "Turnover":
                                teamStat.Turnover = (decimal)item.Value;
                                break;
                        }                        
                    }
                }
            }

            return allStats.Values.ToArray();
        }
    }
}
