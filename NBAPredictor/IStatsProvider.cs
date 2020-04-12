using System.Collections.Generic;
using System.Threading.Tasks;

namespace NBAPredictor
{
    public interface IStatsProvider
    {
        Task GetStatsAsync(Dictionary<string, TeamStats> allStats);
    }
}