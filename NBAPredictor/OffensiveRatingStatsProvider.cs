using HtmlAgilityPack;
using System.Net.Http;

namespace NBAPredictor
{
    public class OffensiveRatingStatsProvider : TeamRankingsWebStatsProvider
    {
        public OffensiveRatingStatsProvider(HttpClient client) : base(client, new OffensiveRatingStatsValidator())
        {
        }

        protected override void FillStats(TeamStats stats, HtmlNode[] columns)
        {
            stats.OffensiveRating = decimal.Parse(columns[2].InnerText);
            stats.OffensiveRatingHome = decimal.Parse(columns[5].InnerText);
            stats.OffensiveRatingAway = decimal.Parse(columns[6].InnerText);
        }
    }
}

