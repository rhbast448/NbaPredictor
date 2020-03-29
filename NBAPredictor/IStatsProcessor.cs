using System.Collections.Generic;

namespace NBAPredictor
{
    public interface IStatsProcessor
    {
        List<Turnover> ProcessRawTurnovers(List<string> rawTurnovers);
    }
}