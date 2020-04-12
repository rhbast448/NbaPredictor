using HtmlAgilityPack;
using System.Globalization;
using System.Net.Http;

namespace NBAPredictor
{
    public class FieldGoalStatsProvider : TeamRankingsWebStatsProvider
    {
        public FieldGoalStatsProvider(HttpClient client) : base(client, new FieldGoalStatsValidator())
        {
        }        

        protected override void FillStats(TeamStats stats, HtmlNode[] columns)
        {
            stats.FieldGoal = decimal.Parse(columns[2].InnerText.TrimEnd('%'), CultureInfo.InvariantCulture);
            stats.FieldGoalHome = decimal.Parse(columns[5].InnerText.TrimEnd('%'), CultureInfo.InvariantCulture);
            stats.FieldGoalAway = decimal.Parse(columns[6].InnerText.TrimEnd('%'), CultureInfo.InvariantCulture);
        }
    }
}
