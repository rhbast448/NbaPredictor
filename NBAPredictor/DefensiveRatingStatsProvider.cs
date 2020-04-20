using HtmlAgilityPack;
using System.Net.Http;

namespace NBAPredictor
{
    public class DefensiveRatingStatsProvider : TeamRankingsWebStatsProvider
    {
        public DefensiveRatingStatsProvider(HttpClient client) : base(client, new DefensiveRatingStatsValidator())
        {
        }

        protected override void FillStats(TeamStats stats, HtmlNode[] columns)
        {
            stats.DefensiveRating = decimal.Parse(columns[2].InnerText);
            stats.DefensiveRatingHome = decimal.Parse(columns[5].InnerText);
            stats.DefensiveRatingAway = decimal.Parse(columns[6].InnerText);
        }
    }
}


