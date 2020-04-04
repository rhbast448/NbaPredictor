using System.Threading.Tasks;

namespace NBAPredictor
{
    public interface IStatsProcessor
    {
        Task<TeamStats[]> GetDailyStatsAsync();
    }
}