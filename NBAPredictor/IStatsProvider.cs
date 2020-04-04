using System.Collections.Generic;
using System.Threading.Tasks;

namespace NBAPredictor
{
    public interface IStatsProvider
    {
        Task<Dictionary<string, object>[]> GetStatsAsync();
    }
}