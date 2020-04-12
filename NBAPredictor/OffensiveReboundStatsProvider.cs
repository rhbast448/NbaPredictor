using HtmlAgilityPack;
using System.Globalization;
using System.Net.Http;

namespace NBAPredictor
{
    public class OffensiveReboundStatsProvider : TeamRankingsWebStatsProvider
    {
        public OffensiveReboundStatsProvider(HttpClient client) : base(client, new OffensiveReboundStatsValidator())
        {
        }

        protected override void FillStats(TeamStats stats, HtmlNode[] columns)
        {
            stats.OffensiveRebound = decimal.Parse(columns[2].InnerText.TrimEnd('%'), CultureInfo.InvariantCulture);
            stats.OffensiveReboundHome = decimal.Parse(columns[5].InnerText.TrimEnd('%'), CultureInfo.InvariantCulture);
            stats.OffensiveReboundAway = decimal.Parse(columns[6].InnerText.TrimEnd('%'), CultureInfo.InvariantCulture);
        }
    }
}


