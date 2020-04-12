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
                await provider.GetStatsAsync(allStats);
            }
            var result = allStats.Values.ToArray();
            return result;
        }
    }
}
