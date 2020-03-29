using System;
using System.Collections.Generic;
using System.Text;

namespace NBAPredictor
{
    internal interface IStatsImporter
    {
        List<string> GetRawTurnovers(string url, string xpath);
    }
}
