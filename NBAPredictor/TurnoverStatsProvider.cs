using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace NBAPredictor
{
    public class TurnoverStatsProvider : TeamRankingsWebStatsProvider
    {
        public TurnoverStatsProvider(HttpClient client) : base(client, new TurnoverStatsValidator())
        {
        }

        protected override void FillStats(TeamStats stats, HtmlNode[] columns)
        {
            stats.Turnover = decimal.Parse(columns[2].InnerText);
            stats.TurnoverHome = decimal.Parse(columns[5].InnerText);
            stats.TurnoverAway = decimal.Parse(columns[6].InnerText);
        }        
    }
}
